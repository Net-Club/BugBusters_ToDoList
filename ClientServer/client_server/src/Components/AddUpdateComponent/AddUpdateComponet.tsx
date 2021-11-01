import Select from 'react-dropdown-select';
import { TaskModel } from '../../Models/TaskModel';
import './AddUpdate.css'

let ButtonText: string
let HeaderText: string

let json: any = localStorage.getItem('task')
let task: TaskModel = new TaskModel(-1, "", "", 0);

function AddUpdateComponent() {
    CheckAddorUp();
    return (
        <form className="form-control, Little">
            <h1 className="h3 mb-3 fw-normal, header">{HeaderText}</h1>
            <div className="Pad">
                <input onChange={event => task.task = event.target.value} value={task.task} id="name" className="Pad, form-control" placeholder="TaskName" required />
            </div>
            <div className="Pad">
                <input onChange={event => task.description = event.target.value} value={task.description} id="description" className="Pad, form-control" placeholder="Description" required />
            </div>

            <div className="dd-wrapper">
                <div className="dd-header">
                    <div className="dd-header-title"></div>
                </div>
                <div className="dd-list">
                    <button className="dd-list-item"></button>
                    <button className="dd-list-item"></button>
                    <button className="dd-list-item"></button>
                </div>
            </div>

            <button className="w-100 btn btn-lg btn-primary" type="button" >{ButtonText}</button>
        </form>
    );
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

export default AddUpdateComponent;