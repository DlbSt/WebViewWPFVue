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
  </div>
</template>

<script setup>
import { ref } from "vue";

const message = ref("");
const sendMessage = () => {
  window.chrome.webview.postMessage({
    type: "notification",
    text: message.value,
  });
};
</script>

<style scoped>
#message {
  border-radius: 5px;
  width: 400px;
  height: 120px;
  background-color: darkslategray;
  padding: 10px;
  margin-bottom: 20px;
}
</style>
