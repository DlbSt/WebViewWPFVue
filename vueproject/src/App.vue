<script setup>
import ComputerInfo from "./components/ComputerInfo.vue";
import ToastNotification from "./components/ToastNotification.vue";
</script>

<template>
  <div>
    <ToastNotification />
    <ComputerInfo />
  </div>
</template>

<style>
input {
  height: 30px;
  width: 300px;
  margin-bottom: 5px;
}

label {
  display: block;
  font-weight: bold;
  font-size: 15px;
  margin-bottom: 5px;
  color: white;
}

button {
  height: 30px;
  margin-top: 5px;
}
</style>
