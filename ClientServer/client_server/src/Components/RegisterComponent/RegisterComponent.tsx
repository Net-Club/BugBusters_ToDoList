import React from 'react';


function Register() {
  return (
    <form>
  
    <h1 className="h3 mb-3 fw-normal, header">Please register</h1>

    <input  type="name" className="form-control" placeholder="Name" required/>

    <input  type="password" className="form-control" placeholder="Password" required/>

    <button className="w-100 btn btn-lg btn-primary" type="submit">Sign in</button>

  </form>
  );
}

export default Register;