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
        ]}
    },
    methods: {
      generateCSV() {
        let csv = 'Sensor type,Instance Name,Value,Date\n';
        this.values.forEach((row) => {
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
