import React from 'react';
import './Navigation.css'
import { Link } from 'react-router-dom';

function Navigation() {
  return (
    <nav className="navbar navbar-expand-md navbar-dark bg-dark mb-4">
      <div className="container-fluid">
        <Link to="/tasks" className="Link">
          <a className="navbar-brand" >ToDoList</a>
        </Link>
        <div>
          <ul className="navbar-nav me-auto mb-2 mb-md-0" >
            <Link to="/login" className="nav-item, d-flex, Link">
              <a className="nav-link active" >LogIn</a>
            </Link>
            <Link to="/" className="nav-item, d-flex, Link">
              <a className="nav-link active" >LogOut</a>
            </Link>
            <Link to="/register" className="nav-item, Link">
              <a className="nav-link active">Register</a>
            </Link>
          </ul>
        </div>
      </div>
    </nav>
  );
}

export default Navigation;