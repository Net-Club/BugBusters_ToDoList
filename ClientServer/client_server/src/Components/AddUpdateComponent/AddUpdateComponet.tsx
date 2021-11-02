import { TextField } from '@material-ui/core';
import { Autocomplete } from '@material-ui/lab';
import { environment } from '../../env';
import { ReturnModel } from '../../Models/ReturnModel';
import { StatusModel } from '../../Models/StatusModel';
import { TaskModel } from '../../Models/TaskModel';
import './AddUpdate.css'

let ButtonText: string
let HeaderText: string

let StatusHandler: string = "";

let json: any = localStorage.getItem('task')
let task: TaskModel = new TaskModel(-1, "", "", 0);

let options: string[] = []

function AddUpdateComponent() {
    CheckAddorUp();
    GetStatuses();
    return (
        <form className="form-control, Little">
            <h1 className="h3 mb-3 fw-normal, header">{HeaderText}</h1>
            <div className="Pad">
                <input onChange={event => task.task = event.target.value} value={task.task} id="name" className="Pad, form-control" placeholder="TaskName" required />
            </div>
            <div className="Pad">
                <input onChange={event => task.description = event.target.value} value={task.description} id="description" className="Pad, form-control" placeholder="Description" required />
            </div>

            <div className="Pad">
                <Autocomplete
                    onChange={(event, value) => SetStatusHandler(value)}
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

            <button className="w-100 btn btn-lg btn-primary" type="button" >{ButtonText}</button>
        </form>
    );
}

function SetStatusHandler(value: any) {
    if (value == null) { StatusHandler = "" }
    else { StatusHandler = value; }

}
function CheckAddorUp() {

    if (localStorage.getItem("task") !== "") {
        ButtonText = "Update"
        HeaderText = "Update task"
        task = JSON.parse(json);
    }
    else {
        ButtonText = "Add"
        HeaderText = "Add task"
    }
}
async function GetStatuses() {
    let data = await GetData();
    let model: ReturnModel = data;

    console.log(model.message);
    if (model.status === 200) {
        SetOptions(model.data);
    }
    else {
        alert(model.message);
    }
}
async function GetData() {
    const requestOptions = {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
    };

    const response = await fetch(environment.GetResUrl("/status"), requestOptions);
    const data = await response.json();
    return data;
}
function SetOptions(data: StatusModel[]) {
    console.log(data)
    for (let i:number = 0; i < data.length; i += 1)
    {
        if (CheckUnique(data[i].status)){options.push(data[i].status)}
    }
}

function CheckUnique(value: string): boolean
{
    for (let i:number = 0; i < options.length; i += 1)
    {
        if (options[i] == value){return false}
    }
    return true
}


export default AddUpdateComponent;


