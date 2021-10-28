import axios from 'axios';
import { env } from '../../env';
import { UserModel } from '../../Models/UserModel';

let name: string = "New";
let password: string = "asdas";

function LogInComponent() {
  return (
    <form>

      <h1 className="h3 mb-3 fw-normal, header">Please sign in</h1>

      <input value={name} id="name" className="form-control" placeholder="Name" required />

      <input value={password} id="password" className="form-control" placeholder="Password" required />

      <button className="w-100 btn btn-lg btn-primary" type="submit" onClick={LogIn}>Sign in</button>

    </form>
  );
}

function LogIn() {
  name = "Yura";
  password = "1111";

  let user: UserModel = new UserModel(name, password);

  

  let headers = { 'Content-Type': 'application/json' }
  let url: string = "http://localhost:32446/auth/authorization";

  alert(url);

  const requestOptions = {
    method: 'POST',
    headers: headers,
    body: JSON.stringify({ user })
  };
  fetch(url, requestOptions)
    .then(response => alert(response.json()))
}

export default LogInComponent;