export class TaskStatusModel 
{
    public id!:number;
    public task!:string;
    public description!:string;
    public user_id!:number;
    public status!:string;
    public status_desc!:string;
    public status_id!:number;

    constructor(id:number, task:string, description:string, user_id:number, status:string, status_desc:string, status_id:number)
    {
        this.id = id;
        this.task = task;
        this.description = description;
        this.user_id = user_id;
        this.status = status;
        this.status_desc = status_desc;
        this.status_id = status_id;
    }
}