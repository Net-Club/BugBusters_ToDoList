import './Navigation.css'
import { Link } from 'react-router-dom';

function Navigation() {
  return (
    <nav className="navbar navbar-expand-md navbar-dark bg-dark mb-4">
      <div className="container-fluid">
          <Link to={ifLogedIn} className="navbar-brand" >ToDoList</Link>
        <div>
          <ul className="navbar-nav me-auto mb-2 mb-md-0" >
            {CheckToken() === false &&
              <Link to="/login" className="nav-item, d-flex, Link">
                <a className="nav-link active" >LogIn</a>
              </Link>
            }
            {CheckToken() === true &&
              <Link to="/" className="nav-item, d-flex, Link" onClick={LogOut}>
                <a className="nav-link active" >LogOut</a>
              </Link>
            }
            {CheckToken() === false &&
              <Link to="/register" className="nav-item, Link">
                <a className="nav-link active">Register</a>
              </Link>
            }
          </ul>
        </div>
      </div>
    </nav>
  );
}

function ifLogedIn(): string
{
  if (CheckToken())
  {
    return "/tasks"
  }
  return "";
}

function CheckToken(): boolean {
  if (localStorage.getItem("token") === "") {
    return false;
  }
  return true;
}

function LogOut() {
  localStorage.setItem("token", "");

  window.history.replaceState(null, "", "/")
  window.location.reload();
}

export default Navigation;