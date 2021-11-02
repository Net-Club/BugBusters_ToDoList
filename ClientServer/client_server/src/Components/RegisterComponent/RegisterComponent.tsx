import { environment } from '../../env'
import { ReturnModel } from '../../Models/ReturnModel'
import { UserModel } from '../../Models/UserModel'
import './Register.css'

let name: string
let password: string

function RegisterComponent() {
  return (
    <form className="form-control, Little">
      <h1 className="h3 mb-3 fw-normal, header">Please register</h1>
      <div className="Pad">
        <input onChange={event => name = event.target.value} value={name} id="name" className="form-control" placeholder="Name" required />
      </div>
      <div className="Pad">
        <input onChange={event => password = event.target.value} value={password} id="password" type="password" className="form-control" placeholder="Password" required />
      </div>
      <button className="w-100 btn btn-lg btn-dark" type="button" onClick={Register}>Register</button>
    </form>
  )
}

async function Register() {
  console.log(environment.GetResUrl("/user"))

  let user: UserModel = new UserModel(name, password)
  let data
  try { data = await SetData(user) }
  catch { alert("Resource server doesn't respond") }
  finally {
    let model: ReturnModel = data

    console.log(model.message)

    if (model.status === 200) {
      window.history.replaceState(null, "", "/login")
      window.location.reload()
    }
    else { alert(model.message) }
  }
}

async function SetData(user: UserModel) {
  const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(user)
  }
  const response = await fetch(environment.GetResUrl("/user"), requestOptions)
  const data = await response.json()
  return data
}

export default RegisterComponent