import axios from 'axios';
import { env } from '../../env';
import { ReturnModel } from '../../Models/ReturnModel';
import { UserModel } from '../../Models/UserModel';

let name: string;
let password: string;
//let data: Array<string>;
let status: number;
let message: string = "test";
let model: ReturnModel;

function LogInComponent() {
  return (
    <form className="form-control">

      <h1 className="h3 mb-3 fw-normal, header">Please sign in</h1>

      <input value={name} id="name" className="form-control" placeholder="Name" required />

      <input value={password} id="password" className="form-control" placeholder="Password" required />

      <button className="w-100 btn btn-lg btn-primary" type="submit" onClick={LogIn}>Sign in</button>
    </form>
  );
}

async function LogInSend(){
  name = "dima";
  password = "1111";

  let user: UserModel = new UserModel(name, password);
  let headers = { 'Content-Type': 'application/json' }
  let url: string = "http://localhost:32446/auth/authorization";

  const requestOptions = {
    method: 'POST',
    headers: headers,
    body: JSON.stringify( user )
  };
  fetch(url, requestOptions)
    .then((response) => {
    return response.json();
  })
    .then((data) => {
    //data = data.data;
    status = data.status;
    message = message;
    console.log(data.message);
  });
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