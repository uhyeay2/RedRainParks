global using MediatR;
global using AutoMapper;
global using DataRequestHandler.Interfaces;
global using DataRequestHandler.Models.DTOs;
global using DataRequestMediator.Responses;
global using RedRainParks.DataAccessMediator;
global using RedRainParks.Domain.Models;
global using FluentValidation;

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("RedRainParks.DataAccessMediator.Tests")]
namespace DataRequestMediator
{
    public class DataRequestMediatorEntryPoint { }
}
