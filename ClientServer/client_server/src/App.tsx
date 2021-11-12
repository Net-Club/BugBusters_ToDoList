import Navigation from './Components/NavigationComponent/Navigation';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import HomeComponent from './Components/HomeComponent/HomeComponent';
import LogInComponent from './Components/LogInComponent/LogInComponent';
import RegisterComponent from './Components/RegisterComponent/RegisterComponent';
import TaskComponent from './Components/TaskComponent/TaskComponent';
import AddComponent from './Components/AddComponet/AddComponent';
import UpdateComponent from './Components/UpdateComponent/UpdateComponet';


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
        <Route path="/add" component={AddComponent}/>
        <Route path="/update" component={UpdateComponent}/>
      </Switch>
      </main>
    </Router>
  );
}

export default App;
