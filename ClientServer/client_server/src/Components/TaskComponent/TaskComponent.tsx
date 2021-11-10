import { TaskModel } from "../../Models/TaskModel"
import { TaskStatusModel } from "../../Models/TaskStatusModel"
import { environment } from '../../env'
import "./Task.css"

let Tasks: Array<TaskStatusModel> = []

InitializeData()

function TaskComponent() {
  return (
    <>
      <div>
        <div className="AddButton">
          <button className="w-100 btn btn-lg btn-dark" type="button" onClick={Add}>Add</button>
        </div>
        <div className="Parent-Container">
          {
            CreateItemList()
          }
        </div>
      </div>
    </>
  );
}

function CreateItemList(): Array<any> {
  let ItemList = []

  for (let i: number = 0; i < Tasks.length; i++) {
    let id: number = Tasks[i].id
    ItemList.push(
      <div key={id}>
        <div className="Container">
          <div className="card shadow-sm">
            <div className="Title">
              <div className="">
                <div className="Header" >{Tasks[i].task}</div>
              </div>
            </div>
            <div className="card-body">
              <div className="Description">
                <div className="ScrollStyle">
                  {Tasks[i].description}
                </div>
              </div>
              <div className="d-flex justify-content-between align-items-center">
                <div className="btn-group">
                  <button type="button" className="btn btn-sm btn-outline-secondary" onClick={() => Edit(id)}>Edit</button>
                  <button id="1" type="button" className="btn btn-sm btn-outline-secondary" onClick={() => { if (window.confirm('Are you sure you want to delete this item?')) { DeleteData(id) } }}>Delete</button>
                </div>
                <div className={ChooseColor(Tasks[i].status)} >{Tasks[i].status}</div>
              </div>
            </div>
          </div>
        </div>
      </div>
    )
  }
  return ItemList
}

function ChooseColor(status: string): string {
  switch (status) {
    case "Done":
      return "Green"
    case "InProgress":
      return "Yellow"
    case "Failed":
      return "Red"
    default:
      return ""
  }
}

async function InitializeData() {
  let Data = null;
  try { Data = await Get() }
  catch {
    alert("Resource server doesn't respond")
    return
  }
  console.log(Data)
  if (Data.status !== 200) {
  }
  else {
    Tasks = Data.data
    console.log(Data.data)
    TaskComponent()
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
  let task: TaskStatusModel = FindByID(id)

  localStorage.setItem("task", JSON.stringify(task))
  window.history.replaceState(null, "", "/update")
  window.location.reload()
}

async function DeleteData(id: number) {
  let Data
  let task: TaskModel = new TaskModel(id, "", "", 0)
  try { Data = await Delete(task) }
  catch {
    alert("Resource server doesn't respond")
    return
  }
  if (Data.status !== 200) {
    alert(Data.message)
  }
  else {
    window.location.reload()
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

function FindByID(id: number) {
  for (let i: number = 0; i < Tasks.length; i++) {
    if (id === Tasks[i].id) { return Tasks[i] }
  }
  return new TaskStatusModel(0, "", "", 0, "", "", 0)
}

export default TaskComponent