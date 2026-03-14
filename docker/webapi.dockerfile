FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /App

COPY ./HotelReservation.WebApi/HotelReservation.slnx .
COPY ./HotelReservation.WebApi/HotelReservation.Domain/ ./HotelReservation.Domain/
COPY ./HotelReservation.WebApi/HotelReservation.Application/ ./HotelReservation.Application/
COPY ./HotelReservation.WebApi/HotelReservation.API/ ./HotelReservation.API/
COPY ./HotelReservation.WebApi/HotelReservation.Infrastructure/ ./HotelReservation.Infrastructure/
COPY ./HotelReservation.WebApi/HotelReservation.CrossCutting/ ./HotelReservation.CrossCutting/

RUN dotnet restore
RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /App
COPY --from=build /App/out .

ENTRYPOINT ["dotnet", "HotelReservation.API.dll"]