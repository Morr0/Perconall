import React from 'react';
import ReactDOM from 'react-dom';
import Home from './main/Home';
import "bootstrap/dist/css/bootstrap.css";

ReactDOM.render(
  <React.StrictMode>
    <header className="nav">Perconall</header>
    <div className="m-2">
        <Home />
    </div>
    <footer>Footer here</footer>
  </React.StrictMode>,
  document.getElementById('root')
);