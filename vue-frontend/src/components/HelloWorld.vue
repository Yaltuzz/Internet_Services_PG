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
            text: 'Instance name',
            align: 'start',
            sortable: false,
            value: 'instanceName',
          },
          { text: 'Value', value: 'pressureValue' },
          { text: 'Date', value: 'date' },
        ],
        values: [
        ]}
    },

    created() {
    axios.get("http://localhost:17644/pressure")
      .then(response => {
        console.log(response.data)
        this.values = response.data})
}
  }
</script>
