import { TextField } from '@material-ui/core'
import { Autocomplete } from '@material-ui/lab'
import { environment } from '../../env'
import { ReturnModel } from '../../Models/ReturnModel'
import { StatusModel } from '../../Models/StatusModel'
import { TaskModel } from '../../Models/TaskModel'
import { TaskStatusModel } from '../../Models/TaskStatusModel'
import './Update.css'

let json: any = localStorage.getItem('task')
let task: TaskStatusModel = new TaskStatusModel(0, "", "", 0, "", "", 0);

let name: string
let description: string
let status: string | null

let Statuses: Array<StatusModel> = []

let options: string[] = []

function UpdateComponent() {
    task = JSON.parse(json)
    name = task.task
    description = task.description
    status = task.status
    GetStatuses()
    return (
        <form className="form-control, Little">
            <h1 className="h3 mb-3 fw-normal, header">Update task</h1>
            <div className="Pad">
                <input onChange={event => name = event.target.value} defaultValue={name} id="name" className="Pad, form-control" placeholder="Task" maxLength={50}/>
            </div>
            <div className="Pad">
                <input onChange={event => description = event.target.value} defaultValue={description} id="description" className="Pad, form-control" placeholder="Description" type="text" required />
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
                    defaultValue={task.status}
                    renderInput={(params) => (
                        <TextField {...params} label="Enter or choose status"
                            variant="outlined" />
                    )}
                />
            </div>

            <button className="w-100 btn btn-lg btn-dark" type="button" onClick={Update}>Update</button>
        </form>
    )
}

async function Update() {
    let model: ReturnModel = new ReturnModel([], 0, "")
    if (status === undefined) {
        alert("Choose status")
    }
    else {

        task = JSON.parse(json)
        task.task = name
        task.description = description
        task.status_id = FindStatusId()
        try{
        model = await Put(task)
        }
        catch { alert("Resource server doesn't respond") }
        finally{
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
        if (status === Statuses[i].status) {
            task.status_desc = Statuses[i].description
            task.status = Statuses[i].status
            return Statuses[i].id
        }
    }
    return 0
}

async function GetStatuses() {
    let data = await GetData()
    let model: ReturnModel = data

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
export default UpdateComponent;


