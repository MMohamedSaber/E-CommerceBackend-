namespace E_CommerceBuisnessLayer
{
   
        public class Result<Tmodel>
        {
            public bool Success { get; set; }
            public object Data { get; set; }

            public static Result<Tmodel> SuccessResult(object data) =>
                new Result<Tmodel> { Success = true, Data = data };

            public static Result<Tmodel> FailureResult() =>
                new Result<Tmodel> { Success = false };
        }
    
}