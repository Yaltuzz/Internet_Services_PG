<template>
  <v-container>
    <v-data-table
    :headers="headers"
    :items="values"
    :items-per-page="5"
    class="elevation-1"
  ></v-data-table>
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
