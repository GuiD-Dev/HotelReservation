FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /App

COPY ./HotelReservation.WebApi/HotelReservation.WebApi.slnx .
COPY ./HotelReservation.WebApi/HotelReservation.WebApi.Domain/ ./HotelReservation.WebApi.Domain/
COPY ./HotelReservation.WebApi/HotelReservation.WebApi.Application/ ./HotelReservation.WebApi.Application/
COPY ./HotelReservation.WebApi/HotelReservation.WebApi.API/ ./HotelReservation.WebApi.API/
COPY ./HotelReservation.WebApi/HotelReservation.WebApi.Infrastructure/ ./HotelReservation.WebApi.Infrastructure/
COPY ./HotelReservation.WebApi/HotelReservation.WebApi.CrossCutting/ ./HotelReservation.WebApi.CrossCutting/

RUN dotnet restore
RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /App
COPY --from=build /App/out .

ENTRYPOINT ["dotnet", "HotelReservation.WebApi.API.dll"]