import React from 'react';
import Navigation from './Components/NavigationComponent/Navigation';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { Redirect } from 'react-router';
import HomeComponent from './Components/HomeComponent/HomeComponent';
import LogInComponent from './Components/LogInComponent/LogInComponent';
import RegisterComponent from './Components/RegisterComponent/RegisterComponent';
import TaskComponent from './Components/TaskComponent/TaskComponent';

function App() {
  return (
    <Router>
      <Navigation></Navigation>
      <main className="form-signin">
      <Switch>
        <Route exact path="/" component={HomeComponent} />
        <Route path="/login" component={LogInComponent}/>
        <Route path="/register" component={RegisterComponent}/>
        <Route path="/tasks" component={TaskComponent}/>
      </Switch>
      </main>
    </Router>
  );
}

export default App;
