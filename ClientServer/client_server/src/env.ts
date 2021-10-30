export class environment
{
    public static GetResUrl(end:string) : string
    {
        return "http://localhost:43073/res" + end;
    }

    public static GetAuthUrl(end:string) : string
    {
        return "http://localhost:32446/auth" + end;
    }
}