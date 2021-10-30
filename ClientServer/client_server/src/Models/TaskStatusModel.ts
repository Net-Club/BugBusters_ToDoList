export class TaskStatusModel 
{
    public id!:number;
    public task!:string;
    public description!:string;
    public user_id!:number;
    public status!:string;
    public status_desc!:string;

    constructor(id:number, task:string, description:string, user_id:number, status:string, status_desc:string)
    {
        this.id = id;
        this.task = task;
        this.description = description;
        this.user_id = user_id;
        this.status = status;
        this.status_desc = status_desc;
    }
}