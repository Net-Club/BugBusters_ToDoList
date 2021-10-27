import { allowedNodeEnvironmentFlags } from 'process';
import React from 'react';
import './LogIn.css'

function LogIn() {
  return (
    <form >
  
    <h1 className="h3 mb-3 fw-normal, header">Please sign in</h1>

    <input id="name"  type="name" className="form-control" placeholder="Name" required/>

    <input id="password" type="password" className="form-control" placeholder="Password" required/>

    <button className="w-100 btn btn-lg btn-primary" type="submit" onClick={_logIn}>Sign in</button>

  </form>
  );
}

function _logIn()
{
  let name = document.getElementById('name')?.textContent;
  let password = document.getElementById('password')?.textContent;

  console.log("name", "password");
}

export default LogIn;