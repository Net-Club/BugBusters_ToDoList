export class TaskModel 
{
    public id!: number;
    public task!: string;
    public description!: string
    public status_id!: number

    constructor(id:number, task:string, description:string, status_id:number)
    {
        this.id = id;
        this.description = description
        this.task = task
        this.status_id = status_id
    }
}