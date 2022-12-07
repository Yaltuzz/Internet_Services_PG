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
  <v-col class="col-12">
                  <canvas
                    class="chart--canvas"
                    id="myChart"
                  ></canvas>
                </v-col>
                <v-col class="col-12">
                  <canvas
                    class="chart--canvas"
                    id="myChart2"
                  ></canvas>
                </v-col>
                <v-col class="col-12">
                  <canvas
                    class="chart--canvas"
                    id="myChart3"
                  ></canvas>
                </v-col>
                <v-col class="col-12">
                  <canvas
                    class="chart--canvas"
                    id="myChart4"
                  ></canvas>
                </v-col>
  </v-container>
</template>

<script>
  import axios from 'axios'

  import Chart from 'chart.js/auto';

  const chartAreaBorder = {
  id: 'chartAreaBorder',
  beforeDraw(chart, args, options) {
    const { ctx, chartArea: { left, top, width, height } } = chart;
    ctx.save();
    ctx.strokeStyle = options.borderColor;
    ctx.lineWidth = options.borderWidth;
    ctx.setLineDash(options.borderDash || []);
    ctx.lineDashOffset = options.borderDashOffset;
    ctx.strokeRect(left, top, width, height);
    ctx.restore();
  },
};

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
      dataFilter:'',
        pres: [],
        hum: [],
        rad: [],
        tem: []
      }
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
      }
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
      this.pres = a.map(s => s.value)
      this.hum = b.map(s => s.value)
      this.rad = c.map(s => s.value)
      this.tem = d.map(s => s.value)
      this.values.sort((a,b) =>{ 
        return  (Date.parse(a.date) - Date.parse(b.date))
      })
    const ctx = document.getElementById('myChart').getContext('2d');
    const ctx2 = document.getElementById('myChart2').getContext('2d');
    const ctx3 = document.getElementById('myChart3').getContext('2d');
    const ctx4 = document.getElementById('myChart4').getContext('2d');
    console.log(this.pres)
    this.chart = new Chart(ctx, {
      type: 'line',
      data: {
        datasets: [
          {
            color: '#fff',
            label: 'Pressure',
            data: this.pres,
            backgroundColor: '#003183',
            borderWidth: 2,
          },
        ],
        labels: [...Array(this.pres.length).keys()],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          chartAreaBorder: {
            borderColor: 'white',
            borderWidth: 0,
            borderDash: [0, 0],
            borderDashOffset: 2,
          },
        },
      },
      plugins: [chartAreaBorder],
    });

    this.chart.resize(0, window.innerHeight - 64 - 24 - 161 - 16 - 24);

    console.log(this.hum)
    this.chart = new Chart(ctx2, {
      type: 'line',
      data: {
        datasets: [
          {
            color: '#fff',
            label: 'Humidity',
            data: this.hum,
            backgroundColor: '#003183',
            borderWidth: 2,
          },
        ],
        labels: [...Array(this.hum.length).keys()],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          chartAreaBorder: {
            borderColor: 'white',
            borderWidth: 0,
            borderDash: [0, 0],
            borderDashOffset: 2,
          },
        },
      },
      plugins: [chartAreaBorder],
    });

    this.chart.resize(0, window.innerHeight - 64 - 24 - 161 - 16 - 24);

    console.log(this.rad)
    this.chart = new Chart(ctx3, {
      type: 'line',
      data: {
        datasets: [
          {
            color: '#fff',
            label: 'Radiation',
            data: this.rad,
            backgroundColor: '#003183',
            borderWidth: 2,
          },
        ],
        labels: [...Array(this.rad.length).keys()],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          chartAreaBorder: {
            borderColor: 'white',
            borderWidth: 0,
            borderDash: [0, 0],
            borderDashOffset: 2,
          },
        },
      },
      plugins: [chartAreaBorder],
    });

    this.chart.resize(0, window.innerHeight - 64 - 24 - 161 - 16 - 24);

    console.log(this.tem)
    this.chart = new Chart(ctx4, {
      type: 'line',
      data: {
        datasets: [
          {
            color: '#fff',
            label: 'Temperature',
            data: this.tem,
            backgroundColor: '#003183',
            borderWidth: 2,
          },
        ],
        labels: [...Array(this.tem.length).keys()],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          chartAreaBorder: {
            borderColor: 'white',
            borderWidth: 0,
            borderDash: [0, 0],
            borderDashOffset: 2,
          },
        },
      },
      plugins: [chartAreaBorder],
    });

    this.chart.resize(0, window.innerHeight - 64 - 24 - 161 - 16 - 24);

  }, 
  }
  
</script>
<style>
.chart--canvas {
  background-color: #fff;
  padding: 20px;
  border-radius: 4px;
  margin-top: 16px;
}
</style>
      this.values.forEach(element => {
          console.log(element.value)
      });
      this.values.sort((a,b) =>{ 
        return  (Date.parse(a.date) - Date.parse(b.date))
      })
} 
  }
</script>