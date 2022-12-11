<template>
  <div>
    <h2>Computer information</h2>
    <div id="cmdData">
      <form>
        <label for="osname">OS Name:</label>
        <input
          type="text"
          id="osname"
          name="osname"
          v-model="computerInfo.osName"
          readonly
        />
        <label for="osver">OS Version:</label>
        <input
          type="text"
          id="osver"
          name="osver"
          v-model="computerInfo.osVersion"
          readonly
        />
        <label for="sysman">System Manufacturer:</label>
        <input
          type="text"
          id="sysman"
          name="sysman"
          v-model="computerInfo.systemManufacturer"
          readonly
        />
        <label for="sysmodel">System Model:</label>
        <input
          type="text"
          id="sysmodel"
          name="sysmodel"
          v-model="computerInfo.systemModel"
          readonly
        />
        <label for="totalmem">Total Memory:</label>
        <input
          type="text"
          id="totalmem"
          name="totalmem"
          v-model="computerInfo.totalMemory"
          readonly
        />
      </form>
      <button @click="getData">Get computer info</button>
    </div>
  </div>
</template>

<script setup>
import { reactive } from "vue";

window.chrome.webview.addEventListener("message", (message) => {
  computerInfo.osName = message.data.osName;
  computerInfo.osVersion = message.data.osVersion;
  computerInfo.systemManufacturer = message.data.systemManufacturer;
  computerInfo.systemModel = message.data.systemModel;
  computerInfo.totalMemory = message.data.totalMemory;
});

const computerInfo = reactive({
  osName: "",
  osVersion: "",
  systemManufacturer: "",
  systemModel: "",
  totalMemory: "",
});

const getData = () => {
  window.chrome.webview.postMessage({
    type: "request",
  });
};
</script>

<style scoped>
#cmdData {
  border-radius: 5px;
  width: 400px;
  height: 375px;
  background-color: darkslateblue;
  padding: 10px;
}
</style>
