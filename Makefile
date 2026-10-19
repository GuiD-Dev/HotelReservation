init-db:
	docker run --name hotel-reservation-db \
		-p 5432:5432 \
		-e POSTGRES_USER=postgres \
		-e POSTGRES_PASSWORD=1234 \
		-e POSTGRES_DB=hotel_reservation_db \
		-d postgres:18

add-migration:
	dotnet ef migrations add $(NAME) \
		--project WebApi.Infrastructure \
		--startup-project HotelReservation.API

apply-migrations:
	dotnet ef database update \
		--project WebApi.Infrastructure \
		--startup-project HotelReservation.API

watch-webapi:
	dotnet watch --project HotelReservation.API

build-webapi:
	docker build -f docker/webapi.dockerfile -t hotel-reservation-webapi .

build-frontend:
	docker build -f docker/frontend.dockerfile -t hotel-reservation-frontend .