<template>
  <v-container>
    <v-data-table
    :headers="headers"
    :items="values"
    :items-per-page="5"
    class="elevation-1"
  ></v-data-table>
  <v-btn 
  @click="generateCSV()">generate csv</v-btn>

  <v-btn 
  @click="generateJSON()">generate JSON</v-btn>


          <input
      type="text"
      v-model="sensorTypeFilter"
      placeholder="Sensor type filter"
    />
    <input
      type="text"
      v-model="instanceIdFilter"
      placeholder="Instance id filter"
    />
    <input
      type="text"
      v-model="dataFilter"
      placeholder="Date filter"
    />
  </v-container>
</template>

<script>
  import axios from 'axios'

  export default {
    name: 'HelloWorld',

    data() {
  return {
    headers: [
          {
            text: 'Sensor type',
            align: 'start',
            sortable: false,
            value: 'sensorType',
          },
          { text: 'Instance Id', value: 'instanceName' },
          { text: 'Value', value: 'value' },
          { text: 'Date', value: 'date' },
        ],
        values: [
        ],
      sensorTypeFilter:'',
      instanceIdFilter:'',
      dataFilter:''}
    },
    methods: {
      generateCSV() {
        let csv = 'Sensor type,Instance Name,Value,Date\n';
        let a = []
        let b = []
        let c = []

        if (this.sensorTypeFilter =='')
        {
          a=this.values
        }
        else{
          a = this.values.filter((x)=>{return x.sensorType == this.sensorTypeFilter})
        }

        if (this.instanceIdFilter =='')
        {
          b=a
        }
        else{
          b = a.filter((x)=>{return x.instanceName == this.instanceIdFilter})
        }

        if (this.dataFilter =='')
        {
          c=b
        }
        else{
          c = b.filter((x)=>{return x.date == this.dataFilter})
        }
        c.forEach((row) => {
                csv += row.sensorType
                csv += ','
                csv += row.instanceName
                csv += ','
                csv += row.value
                csv += ','
                csv += row.date
                csv += "\n";
        });
        const anchor = document.createElement('a');
        anchor.href = 'data:text/csv;charset=utf-8,' + encodeURIComponent(csv);
        anchor.target = '_blank';
        anchor.download = 'atomicSensors.csv';
        anchor.click();
      },
      generateJSON() {
        let x = []
        let b = []
        let c = []

        if (this.sensorTypeFilter =='')
        {
          x=this.values
        }
        else{
          x = this.values.filter((x)=>{return x.sensorType == this.sensorTypeFilter})
        }

        if (this.instanceIdFilter =='')
        {
          b=x
        }
        else{
          b = x.filter((x)=>{return x.instanceName == this.instanceIdFilter})
        }

        if (this.dataFilter =='')
        {
          c=b
        }
        else{
          c = b.filter((x)=>{return x.date == this.dataFilter})
        }

        const data = JSON.stringify(c)
        const blob = new Blob([data], {type: 'text/plain'})
        const e = document.createEvent('MouseEvents'),
        a = document.createElement('a');
        a.download = "test.json";
        a.href = window.URL.createObjectURL(blob);
        a.dataset.downloadurl = ['text/json', a.download, a.href].join(':');
        e.initEvent('click', true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
        a.dispatchEvent(e);
      },
    },
    async created() {
      let a =[]
      let b = []
      let c=[]
      let d=[]
    a=await (await axios.get("http://localhost:17644/pressure")).data
    b = await (await axios.get("http://localhost:17644/humidity")).data
    c=await (await axios.get("http://localhost:17644/radiation")).data
    d = await (await axios.get("http://localhost:17644/temperature")).data
      this.values = [...a, ...b,...c,...d]
      this.values.forEach(element => {
          console.log(element.value)
      });
      this.values.sort((a,b) =>{ 
        return  (Date.parse(a.date) - Date.parse(b.date))
      })
} 
  }
</script>
