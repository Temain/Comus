var ClientRequestViewModel = function (app, dataModel) {
    var self = this;

    self.list = ko.observableArray([]);
    self.selectedPage = ko.observable(1);
    self.pageSizes = ko.observableArray([10, 25, 50, 100, 200]);
    self.selectedPageSize = ko.observable(10);
    self.clientRequestsCount = ko.observable();
    self.pagesCount = ko.observable();

    self.selectedPageChanged = function (page) {
        if (page > 0 && page <= self.pagesCount()) {
            self.selectedPage(page);
            self.loadClientRequests();

            window.scrollTo(0, 0); 
        }
    }

    self.pageSizeChanged = function () {
        self.selectedPage(1);
        self.loadClientRequests();

        window.scrollTo(0, 0);
    };

    Sammy(function () {
        this.get('#clientRequest', function () {
            app.markLinkAsActive('clientRequest');

            self.loadClientRequests();
        });
    });

    //Notification.requestPermission(newMessage);

    //function newMessage(permission) {
    //    if (permission != "granted") return false;
    //    var notify = new Notification("Thanks for letting notify you");
    //};

    self.showNotification = function () {
        // Проверка поддержки браузером уведомлений
        if (!("Notification" in window)) {
            alert("This browser does not support desktop notification");
        }

        // Проверка разрешения на отправку уведомлений
        else if (Notification.permission === "granted") {
            // Если разрешено, то создаем уведомление
            var mailNotification = new Notification("Получена новая заявка!", {
                body: "Обработайте её, пока клиент в сети!",
                icon: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRyqgW8Cys31oPThfxioaARTW21Lg4Iy0QnvY5UhD32RxDyDCZ2"
            });
        }

        // В противном случае, запрашиваем разрешение
        else if (Notification.permission !== 'denied') {
            Notification.requestPermission(function (permission) {
                // Если пользователь разрешил, то создаем уведомление 
                if (permission === "granted") {
                    var mailNotification = new Notification("Получена новая заявка!", {
                        body: "Обработайте её, пока клиент в сети!",
                        icon: "https://png.icons8.com/color/260/filled-message.png"
                    });
                }
            });
        }
    }

    self.loadClientRequests = function () {
        $.ajax({
            method: 'get',
            url: '/api/ClientRequest',
            data: { page: self.selectedPage(), pageSize: self.selectedPageSize() },
            contentType: "application/json; charset=utf-8",
            headers: {
                'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
            },
            success: function (response) {
                ko.mapping.fromJS(response.items, {}, self.list);
                self.pagesCount(response.pagesCount);
                self.clientRequestsCount(response.itemsCount);
                app.view(self);
            }
        });
    }

    self.removeClientRequest = function (clientRequest) {
        $.ajax({
            method: 'delete',
            url: '/api/ClientRequest/' + clientRequest.clientRequestId(),
            data: JSON.stringify(ko.toJS(self)),
            contentType: "application/json; charset=utf-8",
            headers: {
                'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
            },
            success: function (response) {
                self.list.remove(clientRequest);
                showAlert('success', 'Заявка успешно удалена.');
            }
        });
    }

    return self;
}

var EditClientRequestViewModel = function (app, dataModel) {
    var self = this;

    self.company = ko.observable().extend({
        required: {
            params: true,
            message: "Необходимо указать компанию."
        }
    });
    self.lastName = ko.observable().extend({
        required: {
            params: true,
            message: "Необходимо указать фамилию."
        }
    });
    self.firstName = ko.observable().extend({
        required: {
            params: true,
            message: "Необходимо указать имя."
        }
    });

    self.save = function () {
        var result = ko.validation.group(self, { deep: true });
        if (!self.isValid()) {
            result.showAllMessages(true);

            return false;
        }

        $.ajax({
            method: 'put',
            url: '/api/ClientRequest/',
            data: JSON.stringify(ko.toJS(self)),
            contentType: "application/json; charset=utf-8",
            headers: {
                'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
            },
            success: function (response) {
                app.navigateToClientRequest();
                showAlert('success', 'Изменения успешно сохранены.');
            }
        });
    }

    Sammy(function () {
        this.get('#clientRequest/:id', function () {
            app.markLinkAsActive('clientRequest');

            var id = this.params['id'];
            if (id === 'create') {
                $.ajax({
                    method: 'get',
                    url: '/api/ClientRequest/0',
                    contentType: "application/json; charset=utf-8",
                    headers: {
                        'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                    },
                    success: function (response) {
                        var model = app.Views.CreateClientRequest;
                        ko.mapping.fromJS(response, {}, model);
                        var result = ko.validation.group(model, { deep: true });
                        if (!model.isValid()) {
                            result.showAllMessages(false);
                        }
                        app.view(model);
                    }
                });

                // app.view(app.Views.CreateClientRequest);
            } else {
                $.ajax({
                    method: 'get',
                    url: '/api/ClientRequest/' + id,
                    contentType: "application/json; charset=utf-8",
                    headers: {
                        'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
                    },
                    success: function (response) {
                        ko.mapping.fromJS(response, {}, self);
                        app.view(self);
                    }
                });
            }
        });
    });
}

var CreateClientRequestViewModel = function (app, dataModel) {
    var self = this;

    self.company = ko.observable().extend({
        required: {
            params: true,
            message: "Необходимо указать компанию."
        }
    });
    self.discount = ko.observable();
    self.lastName = ko.observable().extend({
        required: {
            params: true,
            message: "Необходимо указать фамилию."
        }
    });
    self.firstName = ko.observable().extend({
        required: {
            params: true,
            message: "Необходимо указать имя."
        }
    });
    self.middleName = ko.observable();
    self.phone = ko.observable();
    self.volumeOfPurchases = ko.observable();
    self.clientSourceId = ko.observable();
    self.clientSources = ko.observableArray([]);
    self.clientStatusId = ko.observable();
    self.clientStatuses = ko.observableArray([]);
    self.productTypeId = ko.observable();
    self.productTypes = ko.observableArray([]);
    self.employeeId = ko.observable();
    self.employees = ko.observableArray([]);
    self.сomment = ko.observable();

    self.save = function () {
        var result = ko.validation.group(self, { deep: true });
        if (!self.isValid()) {
            result.showAllMessages(true);

            return false;
        }

        $.ajax({
            method: 'post',
            url: '/api/ClientRequest/',
            data: JSON.stringify(ko.toJS(self)),
            contentType: "application/json; charset=utf-8",
            headers: {
                'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
            },
            error: function (response) {
                // showAlert('danger', 'Произошла ошибка при добавлении сотрудника. Обратитесь в службу технической поддержки.');
            },
            success: function (response) {
                self.company('');
                self.discount('');
                self.lastName('');
                self.firstName('');
                self.middleName('');
                self.phone('');

                result.showAllMessages(false);

                app.navigateToClientRequest();
                showAlert('success', 'Клиент успешно добавлен.');
            }
        });
    }
}
 
app.addViewModel({
    name: "ClientRequest",
    bindingMemberName: "clientRequest",
    factory: ClientRequestViewModel
});

app.addViewModel({
    name: "EditClientRequest",
    bindingMemberName: "editClientRequest",
    factory: EditClientRequestViewModel
});

app.addViewModel({
    name: "CreateClientRequest",
    bindingMemberName: "createClientRequest",
    factory: CreateClientRequestViewModel
});