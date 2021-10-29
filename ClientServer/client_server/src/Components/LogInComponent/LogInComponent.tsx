import axios from 'axios';
import { allowedNodeEnvironmentFlags } from 'process';
import { env } from '../../env';
import { ReturnModel } from '../../Models/ReturnModel';
import { UserModel } from '../../Models/UserModel';

let name: string;
let password: string;
let status: number;
let message: string = "test";
let model: ReturnModel;

function LogInComponent() {
  return (
    <form className="form-control">

      <h1 className="h3 mb-3 fw-normal, header">Please sign in</h1>

      <input value={name} id="name" className="form-control" placeholder="Name" required />

      <input value={password} id="password" className="form-control" placeholder="Password" required />

      <button className="w-100 btn btn-lg btn-primary" type="submit" onClick={LogInSend}>Sign in</button>
    </form>
  );
}

async function LogInSend() {
  name = "Yura";
  password = "1111";

  let user: UserModel = new UserModel(name, password);
  
  GetData(user);

  console.log(model);
}
async function GetData(user: UserModel) {
  const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify( user )
  };
  const response = await fetch("http://localhost:32446/auth/authorization", requestOptions);
  const data = await response.json();

  model = new ReturnModel(data.data, data.status, data.message);
}




function LogIn() {
  name = "dima";
  password = "1111";
  // fetch(url, requestOptions)
  //   .then(response => console.log(response.json()));

  LogInSend();
  model = new ReturnModel(new Array<string>(), status, message);
  alert(message)
  alert(model.message);
}

export default LogInComponent;