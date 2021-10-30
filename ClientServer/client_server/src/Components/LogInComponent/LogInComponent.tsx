import { ReturnModel } from '../../Models/ReturnModel';
import { UserModel } from '../../Models/UserModel';

let name: string;
let password: string;

function LogInComponent() {
  return (
    <form className="form-control">

      <h1 className="h3 mb-3 fw-normal, header">Please sign in</h1>

      <input onChange={event => name = event.target.value} value={name} id="name" className="form-control" placeholder="Name" required />

      <input onChange={event => password = event.target.value} value={password} id="password" className="form-control" placeholder="Password" required />

      <button className="w-100 btn btn-lg btn-primary" type="button" onClick={LogIn}>Sign in</button>
    </form>
  );
}

async function LogIn() {

  name = "Yura";
  password = "1111";

  let user: UserModel = new UserModel(name, password);
  let data = await GetData(user);
  let model: ReturnModel = data;

  console.log(model.message);
  localStorage.setItem("token", "");
  if (model.data != null) {
    localStorage.setItem("token", model.data[0]);
    window.history.replaceState(null, "", "/tasks")
    window.location.reload();
  }
  else {
    alert(model.message);
  }
}

async function GetData(user: UserModel) {
  const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(user)
  };
  const response = await fetch("http://localhost:32446/auth/authorization", requestOptions);
  const data = await response.json();
  return data;
}

export default LogInComponent;