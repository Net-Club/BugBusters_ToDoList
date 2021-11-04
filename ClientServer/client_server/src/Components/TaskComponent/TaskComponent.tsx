import { TaskModel } from "../../Models/TaskModel"
import { TaskStatusModel } from "../../Models/TaskStatusModel"
import { environment } from '../../env'
import "./Task.css"
import { ReturnModel } from "../../Models/ReturnModel"

let Tasks: Array<TaskStatusModel> = []
let Initialization: boolean = true;

InitializeData()

function TaskComponent() { 
  Initialization = true;
  //InitializeData()
  return (
      <>
      <div className="Parent-Container">
      {
        CreateItemList()
      }
      </div>
      <button type="button" className="btn btn-sm btn-outline-secondary" onClick={Add}>Add</button>
      </>
  );
}

function CreateItemList(): Array<any>
 {
  let ItemList = []

  for (let i: number = 0; i < Tasks.length; i++) {
    ItemList.push(
      <div>
        <div className="col, Container">
          <div className="card shadow-sm">
            <svg className="bd-placeholder-img card-img-top, Rect" ><rect width="100%" height="100%" fill="#55595c" /><text x="50%" y="50%" fill="#eceeef" dy=".3em">{Tasks[i].task}</text></svg>

            <div className="card-body">
              <p className="card-text">{Tasks[i].description}</p>
              <div className="d-flex justify-content-between align-items-center">
                <div className="btn-group">
                  <button type="button" className="btn btn-sm btn-outline-secondary" onClick={() => Edit(Tasks[i].id)}>Edit</button>
                  <button id="1" type="button" className="btn btn-sm btn-outline-secondary" onClick={() => DeleteData(Tasks[i].id)}>Delete</button>
                </div>
                <small className="text-muted">{Tasks[i].status}</small>
              </div>
            </div>
          </div> 
        </div>
      </div>
    )
  }
  return ItemList
}

async function InitializeData() {
  let Data = null;
  try { Data = await Get() }
  catch { alert("Resource server doesn't respond") }
  finally {
    console.log(Data)
    if (Data.status !== 200)
    {
      //alert(Data.message)
    }
    else
    {
      Tasks = Data.data
      console.log(Data.data)
      //Initialization = true;
      TaskComponent()
    }
  }
}

async function Get() {
  const requestOptions = {
    method: 'GET',
    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.getItem("token") }
  }
  const response = await fetch(environment.GetResUrl("/task"), requestOptions)
  const data = await response.json()
  return data
}

function Edit(id: number) {
  let task: TaskModel = new TaskModel(id, FindByID(id).task, FindByID(id).description, 1)
  localStorage.setItem("task", JSON.stringify(task))
  window.history.replaceState(null, "", "/add_update")
  window.location.reload()
}

async function DeleteData(id: number) {
  let Data
  let task: TaskModel = new TaskModel(id, "", "", 0)
  try { Data = await Delete(task) }
  catch { alert("Resource server doesn't respond") }
  finally {
    if (Data.status !== 200) {
      alert(Data.message)
    }
    else {
      window.location.reload()
    }
  }
}

async function Delete(task: TaskModel) {
  const requestOptions = {
    method: 'DELETE',
    headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.getItem("token") },
    body: JSON.stringify(task)
  }
  const response = await fetch(environment.GetResUrl("/task"), requestOptions)
  const data = await response.json()
  return data
}

function Add() {
  window.history.replaceState(null, "", "/add")
  window.location.reload()
}

function FindByID(id: number)
{
  for (let i:number = 0; i < Tasks.length; i++)
  {
    if (id === Tasks[i].id){ return Tasks[i] }
  }
  return new TaskStatusModel(0, "", "", 0, "", "")
}

export default TaskComponent