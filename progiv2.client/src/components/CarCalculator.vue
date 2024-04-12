<script setup lang="ts">
    import { reactive, ref, computed } from 'vue';
    
    interface priceDetails {
        price: number,
        type: string,
        baseFee: number,
        specialFee: number,
        associationFee: number,
        storageFee : number
    }

    const returnInfo = ref<priceDetails>()

    const carInfo = reactive({
        price: 0.00,
        type: "ord"
    });

    const getTotal = computed(() => {
        if (returnInfo.value)
            return returnInfo.value?.price + returnInfo.value?.baseFee + returnInfo.value.specialFee + returnInfo.value.associationFee + returnInfo.value.storageFee;
    })



    const fetchData = () => {
        if (carInfo.price != null) {
        fetch('/carprices', {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(carInfo)
        }).then(r => {
            return r.json();
        })
            .then(json => {
                returnInfo.value = json;
            })
        }
    };


</script>

<template>
  <div>
      <h1>
          Estimation des co&#0251ts
      </h1>
      <div class="inputSection">
      <label for="carPrice">Prix de l'automobile</label>
      <input id="carPrice" type="number" step="10.00" min=0.00 max=100000000.00 v-model="carInfo.price"/>
      <label for="carType">Type de l'automobile</label>
      <select v-model="carInfo.type">
          <option value="ord" selected>Ordinaire</option>
          <option value="luxe">De luxe</option>
      </select>
          <button id="calculateBtn" @click="fetchData">Calculer</button>
      </div>
      <div>

      <table class="table table-dark" v-if="returnInfo != undefined">
          <thead>
              <tr>
                  <th rowspan="2">Prix du v&#233hicule</th>
                  <th rowspan="2">Type de v&#233hicule</th>
                  <th colspan="4">Frais ($)</th>
                  <th rowspan="2">Total ($)</th>
              </tr>
              <tr>
                  <th>De base</th>
                  <th>Sp&#233ciaux</th>
                  <th>Association</th>
                  <th>Entreposage</th>
              </tr>
          </thead>
          <tbody>
              <tr >
                  <td>{{returnInfo?.price.toFixed(2)}} $</td>
                  <td>{{(returnInfo?.type == 'ord')?"Ordinaire":"De Luxe"}}</td>
                  <td>{{returnInfo?.baseFee.toFixed(2)}} $</td>
                  <td>{{returnInfo?.specialFee.toFixed(2)}} $</td>
                  <td>{{returnInfo?.associationFee.toFixed(2)}} $</td>
                  <td>{{returnInfo?.storageFee.toFixed(2)}} $</td>
                  <td>{{getTotal?.toFixed(2)}} $</td>
              </tr>
          </tbody>
      </table>
      </div>
  </div>
  
</template>
<style scoped>
    th, td{
        border : white 1px solid;
        padding: .3rem;
    }
    td{
        text-align: right;
    }
    label, input{
        margin-right : .5rem;
    }
    input {
        width : 5rem;
        padding: .2rem;
    }
    select{
        padding: .2rem;
    }
    .inputSection{
        margin-bottom : 1rem;
    }
    #calculateBtn{
        padding: .2rem;
        margin-left : .5rem;
    }
</style>