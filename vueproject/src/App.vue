<script setup>
import { ref, reactive } from "vue";

window.chrome.webview.addEventListener("message", (message) => {
  console.log(message);
  computerInfo.osName = message.data.osName;
  computerInfo.osVersion = message.data.osVersion;
  computerInfo.systemManufacturer = message.data.systemManufacturer;
  computerInfo.systemModel = message.data.systemModel;
  computerInfo.totalMemory = message.data.totalMemory;
});

const message = ref("");
const sendMessage = () => {
  window.chrome.webview.postMessage(
    {
      type: "notification",
      text: message.value,
    }
    // message.value
  );
};

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

<template>
  <div>
    <h2>Toast notification</h2>
    <div id="message">
      <form>
        <label for="fname">Message:</label>
        <input type="text" id="fname" name="fname" v-model="message" />
      </form>
      <button @click="sendMessage">Send message to WPF app!</button>
    </div>
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

<style scoped>
#message {
  border-radius: 5px;
  width: 400px;
  height: 120px;
  background-color: darkslategray;
  padding: 10px;
  margin-bottom: 20px;
}

#cmdData {
  border-radius: 5px;
  width: 400px;
  height: 375px;
  background-color: darkslateblue;
  padding: 10px;
}

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
