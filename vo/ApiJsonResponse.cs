using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;



public class ApiJsonResponse
{
    public ApiJsonResponse(string message, int code, object data)
    {
        this.message = message;
        this.code = code;
        this.data = data;
    }

    public ApiJsonResponse(Object data)
    {
        this.message = "ok";
        this.code = 200;
        this.data = data;
    }
    
    public ApiJsonResponse()
    {
        this.message = "ok";
        this.code = 200;
    }

    public ApiJsonResponse(int code,String msg)
    {
        this.message = msg;
        this.code = code;
    }

    public ApiJsonResponse(String msg)
    {
        this.message = msg;
        this.code = 500;
    }


    public int code { get; set; }
    public String message{ get; set; }
    public Object data{ get; set; }


    public static JsonResult ok(Object data)
    {
        return toJson(new ApiJsonResponse(data));
    }
    
    
    public static JsonResult ok()
    {
        return toJson(new ApiJsonResponse());
    }


    public static JsonResult errorMsg(String message)
    {
        return toJson(new ApiJsonResponse(message));
    }

    public static JsonResult error(int code,String message)
    {
        return toJson(new ApiJsonResponse(code, message));
    }


    private static JsonResult toJson(Object o) {
        return new JsonResult(o);
    }


   
}