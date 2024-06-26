﻿using Books;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddBooksModule(builder.Configuration);

var app = builder.Build();
app.UseExceptionHandler(opt => { });
app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();
