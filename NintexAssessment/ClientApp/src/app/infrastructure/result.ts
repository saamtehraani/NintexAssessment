export class Result{
    errorList:string[];
    succeeded:boolean;
}

export class ValueResult<T> extends Result{
    value:T;
}

