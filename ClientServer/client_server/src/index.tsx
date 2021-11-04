import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';

localStorage.setItem("token", "")
localStorage.setItem("task", "")

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);
