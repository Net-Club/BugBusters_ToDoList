import React from 'react';
import './LogIn.css'


function LogIn() {
  return (
    <form>
  
    <h1 className="h3 mb-3 fw-normal, header">Please sign in</h1>

    <input  type="name" className="form-control" placeholder="Name" required/>

    <input  type="password" className="form-control" placeholder="Password" required/>

    <button className="w-100 btn btn-lg btn-primary" type="submit">Sign in</button>

  </form>
  );
}

export default LogIn;