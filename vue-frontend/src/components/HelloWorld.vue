<template>
  <v-container>
    <v-data-table
    :headers="headers"
    :items="values"
    :items-per-page="5"
    class="elevation-1"
  ></v-data-table>
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
        pres: [],
        hum: [],
        rad: [],
        tem: []
      }
        ]}
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