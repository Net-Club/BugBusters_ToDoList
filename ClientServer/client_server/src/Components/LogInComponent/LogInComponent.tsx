import { environment } from '../../env';
import { ReturnModel } from '../../Models/ReturnModel';
import { UserModel } from '../../Models/UserModel';
import './LogIn.css'

let name: string;
let password: string;

function LogInComponent() {
  return (
    <form className="form-control, Little">
      <h1 className="h3 mb-3 fw-normal, header">Please sign in</h1>
      <div className="Pad">
        <input onChange={event => name = event.target.value} value={name} id="name" className="Pad, form-control" placeholder="Name" required />
      </div>
      <div className="Pad">
        <input onChange={event => password = event.target.value} value={password} id="password" type="password" className="Pad, form-control" placeholder="Password" required />
      </div>
      <button className="w-100 btn btn-lg btn-primary" type="button" onClick={LogIn}>Sign in</button>
    </form>
  );
}

async function LogIn() {
  let user: UserModel = new UserModel(name, password);
  let data = await GetData(user);
  let model: ReturnModel = data;

  console.log(model.message);
  localStorage.setItem("token", "");
  if (model.status === 200) {
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
  const response = await fetch(environment.GetAuthUrl("/authorization"), requestOptions);
  const data = await response.json();
  return data;
}

export default LogInComponent;