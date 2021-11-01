import { TaskModel } from "../../Models/TaskModel";
import { TaskStatusModel } from "../../Models/TaskStatusModel";
import { environment } from '../../env';
import "./Task.css"

//let Data: Array<TaskStatusModel>;

function TaskComponent() {
  let Data = Get();
  //let Model: Array<TaskStatusModel>(,) = Data;
  return (
    <div className="col, Container">
      <div className="card shadow-sm">
        <svg className="bd-placeholder-img card-img-top, Rect" ><rect width="100%" height="100%" fill="#55595c" /><text x="50%" y="50%" fill="#eceeef" dy=".3em">Name</text></svg>

        <div className="card-body">
          <p className="card-text">Description</p>
          <div className="d-flex justify-content-between align-items-center">
            <div className="btn-group">
              <button type="button" className="btn btn-sm btn-outline-secondary" onClick={Edit}>Edit</button>
              <button type="button" className="btn btn-sm btn-outline-secondary" onClick={Delete}>Delete</button>
            </div>
            <small className="text-muted">Status</small>
          </div>
        </div>
      </div>
      <button type="button" className="btn btn-sm btn-outline-secondary" onClick={Add}>Add</button>
    </div>

  );
}

async function Get() {
  const requestOptions = {
    method: 'GET',
    headers: { 'Content-Type': 'application/json', 'Authorization': 'Baerer ' + localStorage.getItem("token") },
    //body: JSON.stringify()
  };
  const response = await fetch(environment.GetResUrl("/task"), requestOptions);
  const data = await response.json();
  return data;
 };

function Edit() {
  let task: TaskModel = new TaskModel(2, "NewTask", "Description", 1);
  localStorage.setItem("task", JSON.stringify(task))
  window.history.replaceState(null, "", "/add_update")
  window.location.reload();
};

function Delete() { };

function Add() {
  localStorage.setItem("task", "")
  window.history.replaceState(null, "", "/add_update")
  window.location.reload();
};

export default TaskComponent;