# Rubik's cube 2x2 solver program
## Состояние:
Написана программа, которая может крутить кубик, но сама сборка пока что не реализована.
## Описание:
Данная программа предназначена для осуществления сборки кубика рубика 2 на 2.
## Запросы и ответы:
На фронтэнде должен быть 3D интерфейс (3D кубик), позволяющий пользователю окрасить кубик в разные цвета. Потом после нажатия на кнопку для сборки кубика, программа на фронтэнде должна собрать данные о кубике в трёхмерный массив 2x2x2 и отправить его на сервер. На сервере программа собирает кубик и отправляет на фронтэнд список с последовательными движениями для сборки кубика. На фронтэнде данные движения должны отобразиться в виде списка и в виде движений на 3D кубике.
## Примечание:
Из-за того, что программа не тяжёлая её можно полностью реализовать на фронтэнде. Но для дальнейшего масштабирования это плохо, тк более сложные кубики (3x3, 4x4 и тд.) будут иметь более тяжёлые программы, которые будут долго загружаться на фронтэнд. Поэтому лучше сразу делать реализацию через сервер.
