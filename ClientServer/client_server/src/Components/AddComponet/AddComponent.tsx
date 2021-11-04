import { TextField } from '@material-ui/core'
import { Autocomplete } from '@material-ui/lab'
import { environment } from '../../env'
import { ReturnModel } from '../../Models/ReturnModel'
import { StatusModel } from '../../Models/StatusModel'
import { TaskModel } from '../../Models/TaskModel'
import './Add.css'

let name: string
let description: string
let status: string | null
let task: TaskModel
let Statuses: Array<StatusModel> = []

let options: string[] = []

function AddComponent() {
    GetStatuses()
    return (
        <form className="form-control, Little">
            <h1 className="h3 mb-3 fw-normal, header">Add task</h1>
            <div className="Pad">
                <input onChange={event => name = event.target.value} value={name} id="name" className="Pad, form-control" placeholder="Task" maxLength={50} required />
            </div>
            <div className="Pad">
                <input onChange={event => description = event.target.value} value={description} id="description" className="Pad, form-control" placeholder="Description" type="text" required />
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

            <button className="w-100 btn btn-lg btn-dark" type="button" onClick={Add}>Add</button>
        </form>
    )
}

async function Add() {
    let model: ReturnModel = new ReturnModel([], 0, "")
    if (status === undefined) {
        alert("Choose status")
    }
    else {
        if (FindStatusId() === 0) {
            alert("No such status")
        }
        else {
            task = new TaskModel(1, name, description, FindStatusId())
            try { model = await Post(task) }
            catch { alert("Resource server doesn't respond") }
            finally {
                if (model.status !== 200) {
                    alert(model.message)
                }
                else {
                    localStorage.setItem("task", "")
                    window.history.replaceState(null, "", "/tasks")
                    window.location.reload()
                }
            }
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

function FindStatusId(): number {
    for (let i: number = 0; i < options.length; i++) {
        if (status === Statuses[i].status)
            return Statuses[i].id
    }
    return 0
}

async function GetStatuses() {
    let data = await GetData()
    let model: ReturnModel = data
    console.log(model.data)
    if (model.status === 200) {
        SetOptions(model.data)
        Statuses = model.data
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
        if (options[i] === value) { return false }
    }
    return true
}
export default AddComponent;


