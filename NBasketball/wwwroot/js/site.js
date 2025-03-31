// Карусель
function initializeCarousel() {
    const slides = document.querySelector('.carousel-slides');
    const slideElements = document.querySelectorAll('.carousel-slide');
    if (!slides || !slideElements.length) {
        console.log('Карусель не найдена на странице');
        return;
    }

    let currentSlide = 0;
    const numSlides = slideElements.length;

    function showSlide(n) {
        if (n >= numSlides) { currentSlide = 0; }
        if (n < 0) { currentSlide = numSlides - 1; }
        slides.style.transform = `translateX(-${currentSlide * 100}%)`;
    }

    window.nextSlide = function () {
        currentSlide++;
        showSlide(currentSlide);
    };

    window.prevSlide = function () {
        currentSlide--;
        showSlide(currentSlide);
    };

    setInterval(nextSlide, 5000);
}

// Кнопка "Наверх"
function initializeScrollToTop() {
    const button = document.getElementById('scrollToTop');
    if (!button) {
        console.log('Кнопка "Наверх" не найдена на странице');
        return;
    }

    window.onscroll = function () {
        if (document.body.scrollTop > 100 || document.documentElement.scrollTop > 100) {
            button.style.display = "block";
        } else {
            button.style.display = "none";
        }
    };

    button.addEventListener('click', function () {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    });
}

// Увеличение логотипов
function initializeLogoZoom() {
    const logos = document.querySelectorAll('.league-logo');
    if (!logos.length) {
        console.log('Логотипы не найдены на странице');
        return;
    }

    logos.forEach(logo => {
        logo.addEventListener('click', function () {
            const fullImage = new Image();
            fullImage.src = this.src;
            fullImage.alt = this.alt;
            fullImage.style.maxWidth = '50%';
            fullImage.style.maxHeight = '40vh';

            const overlay = document.createElement('div');
            overlay.style.position = 'fixed';
            overlay.style.width = '100%';
            overlay.style.height = '100%';
            overlay.style.backgroundColor = 'rgba(0, 0, 0, 0.7)';
            overlay.style.display = 'flex';
            overlay.style.justifyContent = 'center';
            overlay.style.alignItems = 'center';
            overlay.style.zIndex = '1000';

            overlay.addEventListener('click', function () {
                document.body.removeChild(overlay);
            });

            overlay.appendChild(fullImage);
            document.body.appendChild(overlay);
        });
    });
}

// Загрузка всех игроков
function loadAllPlayers() {
    $.ajax({
        url: '/Home/GetAllPlayers',
        type: 'GET',
        cache: false,
        success: function (data) {
            $('.player-grid').empty();
            if (!data || data.length === 0) {
                $('.player-grid').html('<p>Игроки не найдены</p>');
                return;
            }
            data.forEach(player => {
                $('.player-grid').append(`
                    <div class="player-card" data-player-id="${player.id}">
                        <span class="favorite-icon ${player.isFavorite ? 'active' : ''}">${player.isFavorite ? '♥' : '♡'}</span>
                        <div class="player-image"><img src="${player.imagePath}" alt="${player.name}"></div>
                        <div class="player-info">
                            <h2>${player.name}</h2>
                            <p>${player.teamName} | ${player.position}</p>
                            <p>Дата добавления: ${new Date(player.dateAdded).toLocaleDateString()}</p>
                        </div>
                    </div>
                `);
            });
        },
        error: function (xhr, status, error) {
            console.error('Ошибка загрузки игроков:', error);
            $('.player-grid').html('<p>Ошибка загрузки игроков</p>');
        }
    });
}

// Загрузка игроков с фильтрацией
function loadPlayers() {
    var position = $('#positionFilter').val();
    var team = $('#teamFilter').val();
    $.ajax({
        url: '/Home/FilterPlayers',
        type: 'GET',
        data: { position: position, team: team },
        cache: false,
        success: function (data) {
            console.log('Получены данные игроков:', data);
            $('.player-grid').empty();
            if (data.length === 0) {
                $('.player-grid').html('<p>Игроки не найдены</p>');
                return;
            }
            data.forEach(player => {
                const isFavorite = player.isFavorite;
                $('.player-grid').append(`
                    <div class="player-card" data-position="${player.position}" data-team="${player.teamName}" data-player-id="${player.id}">
                        <span class="favorite-icon ${isFavorite ? 'active' : ''}">${isFavorite ? '♥' : '♡'}</span>
                        <div class="player-image"><img src="${player.imagePath}" alt="${player.name}"></div>
                        <div class="player-info">
                            <h2>${player.name}</h2>
                            <p>${player.teamName} | ${player.position}</p>
                            <p>Дата добавления: ${new Date(player.dateAdded).toLocaleDateString()}</p>
                        </div>
                    </div>
                `);
            });
        },
        error: function (xhr, status, error) {
            console.error('Ошибка загрузки игроков:', error);
            $('.player-grid').html('<p>Ошибка загрузки игроков</p>');
        }
    });
}

// Загрузка избранных игроков
function loadFavoritePlayers() {
    $.ajax({
        url: '/Home/GetFavoritePlayers',
        type: 'GET',
        cache: false,
        success: function (data) {
            $('.favorites-grid').empty();
            if (data.length === 0) {
                $('.favorites-grid').html('<p>У вас нет избранных игроков</p>');
                return;
            }
            data.forEach(player => {
                const isFavorite = player.isFavorite;
                $('.favorites-grid').append(`
                    <div class="player-card" data-player-id="${player.id}">
                        <span class="favorite-icon ${isFavorite ? 'active' : ''}">${isFavorite ? '♥' : '♡'}</span>
                        <div class="player-image"><img src="${player.imagePath}" alt="${player.name}"></div>
                        <div class="player-info">
                            <h2>${player.name}</h2>
                            <p>${player.teamName} | ${player.position}</p>
                            <p>Дата добавления: ${new Date(player.dateAdded).toLocaleDateString()}</p>
                        </div>
                    </div>
                `);
            });
        },
        error: function (xhr, status, error) {
            console.error('Ошибка загрузки избранных игроков:', error);
            $('.favorites-grid').html('<p>Ошибка загрузки избранных игроков</p>');
        }
    });
}

// jQuery-зависимый код
$(document).ready(function () {
    // Проверяем текущую страницу и загружаем соответствующие данные
    if (window.location.pathname.toLowerCase() === '/home/players') {
        loadAllPlayers();
        $('#positionFilter, #teamFilter').change(loadPlayers);
    } else if (window.location.pathname.toLowerCase() === '/home/favorites') {
        loadFavoritePlayers();
    }

    // Обработка формы добавления игрока
    if ($('#addPlayerForm').length) {
        // Функция валидации поля
        function validateField($field) {
            var value = $field.val();
            var errorSpan = $field.next('.validation-message');
            var fieldId = $field.attr('id');

            if (fieldId === 'Name' && !value.trim()) {
                errorSpan.text('Пожалуйста, введите имя игрока');
            } else if (fieldId === 'Position' && !value) {
                errorSpan.text('Пожалуйста, выберите позицию');
            } else if (fieldId === 'TeamId' && !value) {
                errorSpan.text('Пожалуйста, выберите команду');
            } else if (fieldId === 'imageFile' && !$field[0].files[0]) {
                errorSpan.text('Пожалуйста, загрузите фото игрока');
            } else {
                errorSpan.text('');
            }
        }

        // Валидация при изменении каждого поля
        $('#Name, #Position, #TeamId, #imageFile').on('input change', function () {
            validateField($(this));
        });

        // Проверка всех полей при загрузке страницы
        $('#Name, #Position, #TeamId, #imageFile').each(function () {
            validateField($(this));
        });

        $('#addPlayerForm').on('submit', function (e) {
            e.preventDefault();

            // Проверка всех полей перед отправкой
            var errors = [];
            $('#Name, #Position, #TeamId, #imageFile').each(function () {
                validateField($(this));
                if ($(this).next('.validation-message').text()) {
                    errors.push($(this).next('.validation-message').text());
                }
            });

            // Если есть ошибки, показываем общее уведомление
            if (errors.length > 0) {
                $('#addPlayerMessage')
                    .removeClass('alert-success')
                    .addClass('alert-danger')
                    .text('Проверьте правильность заполнения формы')
                    .fadeIn();
                return;
            }

            // Отправка формы
            var formData = new FormData(this);

            $.ajax({
                url: '/Home/AddPlayerAjax',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    var $message = $('#addPlayerMessage');
                    if (response.success) {
                        $message
                            .removeClass('alert-danger')
                            .addClass('alert-success')
                            .text(response.message)
                            .fadeIn()
                            .delay(3000)
                            .fadeOut();

                        $('#addPlayerForm')[0].reset();
                        $('.validation-message').text(''); // Очистка сообщений после успеха

                        if (window.location.pathname.toLowerCase() === '/home/players') {
                            loadAllPlayers();
                        } else {
                            setTimeout(function () {
                                window.location.href = '/Home/Players';
                            }, 1000);
                        }
                    } else {
                        $message
                            .removeClass('alert-success')
                            .addClass('alert-danger')
                            .text(response.message)
                            .fadeIn();

                        // Отображение серверных ошибок под соответствующими полями
                        if (response.errors && response.errors.length > 0) {
                            response.errors.forEach(error => {
                                if (error.includes('Имя')) $('#NameError').text(error);
                                if (error.includes('Позиция')) $('#PositionError').text(error);
                                if (error.includes('Команда')) $('#TeamIdError').text(error);
                                if (error.includes('Фото')) $('#ImageFileError').text(error);
                            });
                        }
                    }
                },
                error: function (xhr, status, error) {
                    $('#addPlayerMessage')
                        .removeClass('alert-success')
                        .addClass('alert-danger')
                        .text('Ошибка при добавлении игрока: ' + (xhr.responseJSON?.message || error))
                        .fadeIn();
                }
            });
        });
    }

    // Загрузка лиг с пагинацией
    const $teamsList = $('#teams-list');
    let currentPage = 1;
    let isLoading = false;

    function loadLeagues(page) {
        if (isLoading) return;
        isLoading = true;

        $.ajax({
            url: '/Home/GetLeaguesPaginated',
            type: 'GET',
            data: { page: page },
            cache: false,
            success: function (data) {
                console.log('Загруженные лиги:', data.leagues);
                if (page === 1) {
                    $teamsList.empty();
                }

                data.leagues.forEach(league => {
                    if ($teamsList.find(`.league-section[data-league="${league.name}"]`).length === 0) {
                        const logoName = league.name.toLowerCase().replace(" ", "");
                        $teamsList.append(`
                            <div class="league-section" data-league="${league.name}">
                                <details>
                                    <summary>
                                        <img src="/assets/${logoName}-logo.png" alt="${league.name} Logo" class="league-logo" />
                                        ${league.displayName}
                                    </summary>
                                    <p>${league.description}</p>
                                    <ul class="team-list" data-league="${league.name}"></ul>
                                </details>
                            </div>
                        `);
                    }
                });

                const $showMoreBtn = $('#show-more-btn');
                if (data.hasMore && $showMoreBtn.length === 0) {
                    $teamsList.after('<button id="show-more-btn" class="btn btn-primary">Показать еще</button>');
                } else if (!data.hasMore && $showMoreBtn.length > 0) {
                    $showMoreBtn.remove();
                }

                isLoading = false;
            },
            error: function (xhr, status, error) {
                console.error('Ошибка при загрузке лиг:', error);
                $teamsList.append('<p>Ошибка загрузки лиг</p>');
                isLoading = false;
            }
        });
    }

    if ($teamsList.length) {
        loadLeagues(currentPage);
    }

    $(document).on('click', '#show-more-btn', function () {
        currentPage++;
        loadLeagues(currentPage);
    });

    // Умный поиск для Teams.cshtml
    const $searchInput = $('#search-input');
    const $suggestions = $('#suggestions');
    if ($searchInput.length && $suggestions.length) {
        $searchInput.on('input', function () {
            const searchTerm = $(this).val().trim();

            if (searchTerm.length < 1) {
                $suggestions.hide().empty();
                $('.league-section').show();
                return;
            }

            $.ajax({
                url: '/Home/SearchLeagues',
                type: 'GET',
                data: { searchTerm: searchTerm },
                cache: false,
                success: function (data) {
                    $suggestions.empty();
                    if (data.length === 0) {
                        $suggestions.append('<li>Лиги не найдены</li>');
                    } else {
                        data.forEach(league => {
                            $suggestions.append(`<li data-league="${league.name}">${league.displayName}</li>`);
                        });
                    }
                    $suggestions.show();
                },
                error: function (xhr, status, error) {
                    console.error('Ошибка при поиске лиг:', error);
                    $suggestions.empty().append('<li>Ошибка поиска</li>').show();
                }
            });
        });

        $suggestions.on('click', 'li', function () {
            const leagueName = $(this).data('league');
            if (!leagueName) return;

            $suggestions.hide();
            $searchInput.val('');

            $('.league-section').hide();
            const $selectedLeague = $(`.league-section[data-league="${leagueName}"]`);
            if ($selectedLeague.length) {
                $selectedLeague.show();
                $selectedLeague.find('details').attr('open', true);
            } else {
                $.ajax({
                    url: '/Home/GetLeagueDetails',
                    type: 'GET',
                    data: { leagueName: leagueName },
                    cache: false,
                    success: function (league) {
                        if (league.name && $teamsList.find(`.league-section[data-league="${league.name}"]`).length === 0) {
                            const logoName = league.name.toLowerCase().replace(" ", "");
                            $teamsList.append(`
                                <div class="league-section" data-league="${league.name}">
                                    <details open>
                                        <summary>
                                            <img src="/assets/${logoName}-logo.png" alt="${league.name} Logo" class="league-logo" />
                                            ${league.displayName}
                                        </summary>
                                        <p>${league.description}</p>
                                        <ul class="team-list" data-league="${league.name}"></ul>
                                    </details>
                                </div>
                            `);
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error('Ошибка при загрузке лиги:', error);
                        $teamsList.html('<p>Ошибка при загрузке лиги</p>');
                    }
                });
            }
        });

        $(document).on('click', function (e) {
            if (!$(e.target).closest('#search-container').length) {
                $suggestions.hide();
            }
        });
    }

    // Добавление/удаление из избранного
    $(document).on('click', '.favorite-icon', function (event) {
        event.preventDefault();
        event.stopPropagation();
        var playerId = $(this).closest('.player-card').data('player-id');
        var $icon = $(this);

        if ($icon.hasClass('processing')) return;
        $icon.addClass('processing');

        console.log(`Отправка запроса ToggleFavorite для PlayerId: ${playerId}`);

        $.ajax({
            url: '/Home/ToggleFavorite',
            type: 'POST',
            data: { playerId: playerId },
            cache: false,
            success: function (response) {
                console.log(`Ответ от ToggleFavorite:`, response);
                if (response.success) {
                    $icon.toggleClass('active', response.isFavorite);
                    $icon.text(response.isFavorite ? '♥' : '♡');
                    var $message = $('#favorite-message');
                    $message.text(response.message);
                    $message.fadeIn();
                    setTimeout(function () { $message.fadeOut(); }, 3000);

                    if (window.location.pathname.toLowerCase() === '/home/players') {
                        if ($('#positionFilter').val() || $('#teamFilter').val()) {
                            loadPlayers();
                        } else {
                            loadAllPlayers();
                        }
                    } else if (window.location.pathname.toLowerCase() === '/home/favorites') {
                        loadFavoritePlayers();
                    }
                } else {
                    alert('Не удалось изменить статус избранного.');
                }
                $icon.removeClass('processing');
            },
            error: function (xhr, status, error) {
                console.error('Ошибка при добавлении в избранное:', error);
                alert('Ошибка при добавлении в избранное. Попробуйте снова.');
                $icon.removeClass('processing');
            }
        });
    });
});

// Инициализация функций, не зависящих от jQuery
document.addEventListener('DOMContentLoaded', function () {
    initializeCarousel();
    initializeScrollToTop();
    initializeLogoZoom();

    // Загрузка команд при раскрытии лиги
    document.addEventListener('toggle', function (e) {
        if (e.target.tagName === 'DETAILS') {
            console.log('Событие toggle сработало');
            var $details = $(e.target);
            var league = $details.find('.team-list').data('league');
            var $teamList = $details.find('.team-list');

            console.log('Лига:', league);
            if ($details.prop('open') && $teamList.children().length === 0) {
                $teamList.html('<li>Загрузка...</li>');
                $.ajax({
                    url: '/Home/GetTeamsByLeague',
                    type: 'GET',
                    data: { league: league },
                    cache: false,
                    success: function (data) {
                        console.log('Данные команд:', data);
                        $teamList.empty();
                        if (data.length === 0) {
                            $teamList.html('<li>Команды не найдены</li>');
                        } else {
                            data.forEach(function (team) {
                                $teamList.append(`
                                    <li>
                                        <a href="${team.url}">${team.name}</a>
                                    </li>
                                `);
                            });
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error('Ошибка при подгрузке команд:', error);
                        $teamList.html('<li>Ошибка загрузки команд</li>');
                    }
                });
            }
        }
    }, true);
});