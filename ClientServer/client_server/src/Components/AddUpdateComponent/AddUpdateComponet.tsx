import { TextField } from '@material-ui/core'
import { Autocomplete } from '@material-ui/lab'
import { environment } from '../../env'
import { ReturnModel } from '../../Models/ReturnModel'
import { StatusModel } from '../../Models/StatusModel'
import { TaskModel } from '../../Models/TaskModel'
import './AddUpdate.css'

let isAdd: boolean
let ButtonText: string
let HeaderText: string

let name: string
let description: string
let status: string | null

let json: any = localStorage.getItem('task')
let task: TaskModel

let options: string[] = []

function AddUpdateComponent() {
    GetStatuses()
    CheckAddorUp()
    return (
        <form className="form-control, Little">
            <h1 className="h3 mb-3 fw-normal, header">{HeaderText}</h1>
            <div className="Pad">
                <input onChange={event => name = event.target.value} value={name} id="name" className="Pad, form-control" placeholder="Name" required />
            </div>
            <div className="Pad">
                <input onChange={event => description = event.target.value} value={description} id="description" className="Pad, form-control" placeholder="Description" required />
            </div>

            <div className="Pad">
                <Autocomplete
                    onChange={(event, value) => status = value}
                    selectOnFocus
                    clearOnBlur
                    handleHomeEndKeys
                    options={options}
                    renderOption={(option) => option}
                    freeSolo
                    renderInput={(params) => (
                        <TextField {...params} label="Enter or choose status"
                            variant="outlined" />
                    )}
                />
            </div>

            <button className="w-100 btn btn-lg btn-dark" type="button" onClick={Click}>{ButtonText}</button>
        </form>
    )
}

function CheckAddorUp() {

    if (localStorage.getItem("task") !== "") {
        ButtonText = "Update"
        HeaderText = "Update task"
        isAdd = false
    }
    else {
        ButtonText = "Add"
        HeaderText = "Add task"
        isAdd = true
    }
}

async function Click() {
    let model: ReturnModel = new ReturnModel([], 0, "")
    if (status === undefined) {
        alert("Choose status")
    }
    else {
        if (isAdd) {
            task = new TaskModel(0, name, description, FindStatusId())
            try{model = await Post(task)}
            catch{ alert("Resource server doesn't respond") }
        }
        else {
            task = JSON.parse(json)
            task.task = name
            task.description = description
            task.status_id = FindStatusId()
            try {model = await Put(task)}
            catch { alert("Resource server doesn't respond") }
        }
        if (model.status !== 200) {
            alert(model.message)
        }
        else {
            window.history.replaceState(null, "", "/tasks")
            window.location.reload()
        }
    }
}

async function Post(task: TaskModel) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.getItem("token") },
        body: JSON.stringify(task)
    };
    const response = await fetch(environment.GetResUrl("/task"), requestOptions)
    const data = await response.json()
    return data;
}

async function Put(task: TaskModel) {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.getItem("token") },
        body: JSON.stringify(task)
    };
    const response = await fetch(environment.GetResUrl("/task"), requestOptions)
    const data = await response.json()
    return data;
}

function FindStatusId(): number {
    for (let i: number = 0; i < options.length; i++) {
        if (status === options[i])
            return i
    }
    return 0
}

async function GetStatuses() {
    let data = await GetData()
    let model: ReturnModel = data

    if (model.status === 200) {
        SetOptions(model.data)
    }
    else {
        alert(model.message)
    }
}

async function GetData() {
    const requestOptions = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    };

    const response = await fetch(environment.GetResUrl("/status"), requestOptions)
    const data = await response.json()
    return data;
}

function SetOptions(data: StatusModel[]) {
    for (let i: number = 0; i < data.length; i += 1) {
        if (CheckUnique(data[i].status)) { options.push(data[i].status) }
    }
}

function CheckUnique(value: string): boolean {
    for (let i: number = 0; i < options.length; i += 1) {
        if (options[i] == value) { return false }
    }
    return true
}
export default AddUpdateComponent;


