using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RentWheelzDataAccessLayer.Models;
using RentWheelzDataAccessLayer.Repositories;
using RentWheelzWebApi.Controllers;
using RentWheelzWebApi.Interfaces;
using RentWheelzWebApi.Messages;
using RentWheelzWebApi.Models;
using RentWheelzWebApi.Services;

namespace RentWheelzWebApiTests.Tests
{
    public class RentWheelzReservationControllerTests
    {
        private readonly RentWheelzReservationController _controller;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IRentWheelzReservationService> _serviceMock;
        private readonly Mock<IRentWheelzReservationRepository> _reservationRepositoryMock;
        private readonly Mock<IRentWheelzVehicleRepository> _vehicleRepositoryMock;
        private readonly Mock<IRentWheelzUserRepository> _userRepositoryMock;


        public RentWheelzReservationControllerTests()
        {
            _mapperMock = new Mock<IMapper>();
            _reservationRepositoryMock = new Mock<IRentWheelzReservationRepository>();
            _vehicleRepositoryMock = new Mock<IRentWheelzVehicleRepository>();
            _userRepositoryMock = new Mock<IRentWheelzUserRepository>();
            _serviceMock = new Mock<IRentWheelzReservationService>();
            _controller = new RentWheelzReservationController(_serviceMock.Object);
        }

        [Fact]
        public void GetReservations_ReturnsOkResultWithReservations()
        {
            // Arrange
            var reservations = new List<Reservation>
            {
                new Reservation { ReservationId = 1, UserId = 1, VehicleId = 1, Duration = 2 },
                new Reservation { ReservationId = 2, UserId = 2, VehicleId = 2, Duration = 3 }
            };

            _serviceMock.Setup(service => service.GetReservations()).Returns(reservations);

            // Act
            var result = _controller.GetReservations();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Reservation>>(okResult.Value);
            Assert.Equal(reservations, returnValue);
        }

        [Fact]
        public void GetReservationById_ReturnsOkResultWithReservation()
        {
            // Arrange
            var reservation = new Reservation { ReservationId = 1, UserId = 1, VehicleId = 1, Duration = 2 };
            var modelReservation = new ModelReservationApi { ReservationId = 1, UserId = 1, VehicleId = 1, Duration = 2 };
            var messageSuccess = "Reservation successfully loaded.";

            _serviceMock.Setup(service => service.GetReservationById(1)).Returns(modelReservation);

            // Act
            var result = _controller.GetReservationById(1);

            // Assert
            var okResult = Assert.IsType<JsonResult>(result);
            var expectedValue = Assert.IsType<ReservationMessage>(okResult.Value);
            Assert.Equal(modelReservation, expectedValue.Reservation);
            Assert.Equal(messageSuccess, expectedValue.Message);
        }

        [Fact]
        public void AddReservation_ReturnsOkResultWithMessage()
        {
            // Arrange
            var reservation = new Reservation { ReservationId = 1, UserId = 1, VehicleId = 1, Duration = 2 };
            var messageSuccess = "Reservation successfully added.";

            _serviceMock.Setup(service => service.AddReservation(reservation)).Returns(true);

            // Act
            var result = _controller.AddReservation(reservation);

            // Assert
            var okResult = Assert.IsType<JsonResult>(result);
            var expectedValue = Assert.IsType<ReservationMessage>(okResult.Value);
            Assert.Equal(messageSuccess, expectedValue.Message);
        }

        [Fact]
        public void CancelReservation_ReturnsOkResultWithMessage()
        {
            // Arrange
            var reservationId = 1;
            var messageSuccess = "Reservation successfully cancelled.";

            _serviceMock.Setup(service => service.CancelReservation(reservationId)).Returns(true);

            // Act
            var result = _controller.CancelReservation(reservationId);

            // Assert
            var okResult = Assert.IsType<JsonResult>(result);
            var expectedValue = Assert.IsType<ReservationMessage>(okResult.Value);
            Assert.Equal(messageSuccess, expectedValue.Message);
        }

        [Fact]
        public void CloseReservation_ReturnsOkResultWithMessage()
        {
            // Arrange
            var reservationId = 1;
            var messageSuccess = "Reservation successfully closed.";

            _serviceMock.Setup(service => service.CloseReservation(reservationId)).Returns(true);

            // Act
            var result = _controller.CloseReservation(reservationId);

            // Assert
            var okResult = Assert.IsType<JsonResult>(result);
            var expectedValue = Assert.IsType<ReservationMessage>(okResult.Value);
            Assert.Equal(messageSuccess, expectedValue.Message);
        }


        [Fact]
        public void GetReservationById_ReturnsNoContentResult()
        {
            // Arrange
            var modelReservation = (ModelReservationApi?)null;
            var messageFailed = "Reservation not found.";

            _serviceMock.Setup(service => service.GetReservationById(1)).Returns(modelReservation);

            // Act
            var result = _controller.GetReservationById(1);

            // Assert
            var okResult = Assert.IsType<JsonResult>(result);
            var expectedValue = Assert.IsType<ReservationMessage>(okResult.Value);
            Assert.Equal(messageFailed, expectedValue.Message);
        }

        [Fact]
        public void AddReservation_ReturnsBadRequestResult()
        {
            // Arrange
            var reservation = new Reservation { ReservationId = 1, UserId = 1, VehicleId = 1, Duration = 2 };
            var messageFailed = "Reservation failed.";

            _serviceMock.Setup(service => service.AddReservation(reservation)).Returns(false);

            // Act
            var result = _controller.AddReservation(reservation);

            // Assert
            var okResult = Assert.IsType<JsonResult>(result);
            var expectedValue = Assert.IsType<ReservationMessage>(okResult.Value);
            Assert.Equal(messageFailed, expectedValue.Message);
        }

        [Fact]
        public void CancelReservation_ReturnsBadRequestResult()
        {
            // Arrange
            var reservationId = 1;
            var messageFailed = "Cancellation failed.";

            _serviceMock.Setup(service => service.CancelReservation(reservationId)).Returns(false);

            // Act
            var result = _controller.CancelReservation(reservationId);

            // Assert
            var okResult = Assert.IsType<JsonResult>(result);
            var expectedValue = Assert.IsType<ReservationMessage>(okResult.Value);
            Assert.Equal(messageFailed, expectedValue.Message);
        }


        [Fact]
        public void CloseReservation_ReturnsBadRequestResult()
        {
            // Arrange
            var reservationId = 1;
            var messageFailed = "Closing failed.";

            _serviceMock.Setup(service => service.CloseReservation(reservationId)).Returns(false);

            // Act
            var result = _controller.CloseReservation(reservationId);

            // Assert
            var okResult = Assert.IsType<JsonResult>(result);
            var expectedValue = Assert.IsType<ReservationMessage>(okResult.Value);
            Assert.Equal(messageFailed, expectedValue.Message);
        }

    }
}
