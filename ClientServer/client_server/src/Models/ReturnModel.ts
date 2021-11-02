export class ReturnModel{
    public data!: Array<any>;
    public status!: number;
    public message!: string;

    constructor(data:Array<any>, status:number, message:string)
    {
        this.data = data;
        this.status = status;
        this.message = message;
    }

    public setMessage(message: string){
        this.message = message;
    }

    public Set(data:Array<any>, status:number, message:string)
    {
        this.data = data;
        this.status = status;
        this.message = message;
    }
}

