# JAVASCRIPT

## Global object
Глобальный объект - это объект, который всегда существует в глобальной области видимости.

В JavaScript всегда определён глобальный объект. В веб-браузере, когда скрипты создают глобальные переменные, они создаются как свойства глобального объекта. (В Node.js это не так.) Interface глобального объекта зависит от контекста, в котором выполняется скрипт.К примеру:

  - В веб-браузере любой код, который не запускается скриптом явно как фоновую задачу, имеет Window в качестве своего глобального объекта. Это покрывает большую часть JavaScript-кода в сети.
  - Код, работающий в Worker имеет WorkerGlobalScope объект в качестве своего глобального объекта.
  - Скрипты, работающие в Node.js имеют объект, который называется global в качестве своего глобального объекта.
  
**Объект `window` в Браузере**
Объект `window` - Глобальный Объект в браузере. Доступ к любым Глобальным Переменным или функциям может быть получен как к свойствам объекта `window`.

Получение доступа к Глобальным Переменным

```
var foo = "foobar";
foo === window.foo; // Возвращает: true
```

После определения Глобальной Переменной `foo`, мы можем получить доступ к его значению прямо с объекта `window`, использую имя переменной `foo` в качестве имени свойства Глобального Объекта `window.foo`.

*Объяснение*:
Глобальная Переменная foo была сохранена в объекте window, подобно следующему примеру:

```
foo: "foobar"
```

Получение доступа к Глобальным Функциям

```
function greeting() {
   console.log("Hi!");
}

window.greeting(); // Тоже самое что и обычный вызов: greeting();
```

Пример выше показывает как Глобальные Функции хранятся в качестве свойств объекта window. Мы создали Глобальную Функцию greeting и вызвали её с помощью объекта window.

## Классы
Классы в JavaScript были введены в ECMAScript 2015 и представляют собой синтаксический сахар над существующим в JavaScript механизмом прототипного наследования. Синтаксис классов не вводит новую объектно-ориентированную модель, а предоставляет более простой и понятный способ создания объектов и организации наследования.

### Определение классов
На самом деле классы — это "специальные функции", поэтому точно также, как вы определяете функции ([function expression](https://developer.mozilla.org/ru/docs/Web/JavaScript/Reference/Operators/function) и [function declarations](https://developer.mozilla.org/ru/docs/Web/JavaScript/Reference/Statements/function)), вы можете определять и классы с помощью: [class declarations](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/class) и [class expressions](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/class).

**Объявление класса**
Первый способ определения класса — *class declaration* (объявление класса). Для этого необходимо воспользоваться ключевым словом `class` и указать имя класса (в примере — «Rectangle»).

```
class Rectangle {
  constructor(height, width) {
    this.height = height;
    this.width = width;
  }
}
```

## Тело класса и задание методов
Тело класса — это часть кода, заключённая в фигурные скобки {}. Здесь вы можете объявлять члены класса, такие как методы и конструктор.

### Строгий режим
Тела объявлений классов и выражений классов выполняются в строгом режиме (strict mode).

### Constructor
Метод constructor — специальный метод, необходимый для создания и инициализации объектов, созданных, с помощью класса. В классе может быть только один метод с именем constructor. Исключение типа SyntaxError будет выброшено, если класс содержит более одного вхождения метода constructor.

Ключевое слово super можно использовать в методе constructor для вызова конструктора родительского класса.

### Методы прототипа
Смотрите также определение методов.

```
class Rectangle {
  constructor(height, width) {
    this.height = height;
    this.width = width;
  }

  get area() {
    return this.calcArea();
  }

  calcArea() {
    return this.height * this.width;
  }
}

const square = new Rectangle(10, 10);

console.log(square.area); // 100
```

### Статические методы  и свойства
Ключевое слово static, определяет статический метод или свойства для класса. Статические методы и свойства вызываются без инстанцирования (en-US) их класса, и не могут быть вызваны у экземпляров (instance) класса. Статические методы, часто используются для создания служебных функций для приложения, в то время как статические свойства полезны для кеширования в рамках класса, фиксированной конфигурации или любых других целей, не связанных с реплецированием данных между экземплярами.

```
class Point {
  constructor(x, y) {
    this.x = x;
    this.y = y;
  }

  static displayName = "Точка";
  static distance(a, b) {
    const dx = a.x - b.x;
    const dy = a.y - b.y;

    return Math.hypot(dx, dy);
  }
}

const p1 = new Point(5, 5);
const p2 = new Point(10, 10);
p1.displayName; //undefined
p1.distance;    //undefined
p2.displayName; //undefined
p2.distance;    //undefined

console.log(Point.displayName);      // "Точка"
console.log(Point.distance(p1, p2)); // 7.0710678118654755
```

### Привязка this в прототипных и статических методах
Когда статический или прототипный метод вызывается без привязки к this объекта (или когда this является типом boolean, string, number, undefined, null), тогда this будет иметь значение undefined внутри вызываемой функции. Поведение будет таким же даже без директивы "use strict", потому что код внутри тела класса всегда выполняется в строгом режиме.

```
class Animal {
  speak() {
    return this;
  }
  static eat() {
    return this;
  }
}

let obj = new Animal();
obj.speak(); // объект Animal
let speak = obj.speak;
speak(); // undefined

Animal.eat() // класс Animal
let eat = Animal.eat;
eat(); // undefined
```

Если мы напишем этот же код используя классы основанные на функциях, тогда произойдёт автоупаковка основанная на значении this, в течение которого функция была вызвана. В строгом режиме автоупаковка не произойдёт - значение this останется прежним.

```
function Animal() { }

Animal.prototype.speak = function(){
  return this;
};

Animal.eat = function() {
  return this;
};

let obj = new Animal();
let speak = obj.speak;
speak(); // глобальный объект (нестрогий режим)

let eat = Animal.eat;
eat(); // глобальный объект (нестрогий режим)
```

### Свойства экземпляра
Свойства экземпляра должны быть определены в методе класса:

```
class Rectangle {
  constructor(height, width) {
    this.height = height;
    this.width = width;
  }
}
```

Статические (class-side) свойства и свойства прототипа должны быть определены за рамками тела класса:

```
Rectangle.staticWidth = 20;
Rectangle.prototype.prototypeWidth = 25;
```

## Наследование классов с помощью `extends`
Ключевое слово `extends` используется в объявлениях классов и выражениях классов для создания класса, дочернего относительно другого класса.

```
class Animal {
  constructor(name) {
    this.name = name;
  }

  speak() {
    console.log(`${this.name} издаёт звук.`);
  }
}

class Dog extends Animal {
  constructor(name) {
    super(name); // вызывает конструктор super класса и передаёт параметр name
  }

  speak() {
    console.log(`${this.name} лает.`);
  }
}

let d = new Dog('Митци');
d.speak(); // Митци лает
```

Если в подклассе присутствует конструктор, он должен сначала вызвать super, прежде чем использовать `this`.

Аналогичным образом можно расширять традиционные, основанные на функциях "классы":

```
function Animal (name) {
  this.name = name;
}
Animal.prototype.speak = function () {
  console.log(`${this.name} издаёт звук.`);
}

class Dog extends Animal {
  speak() {
    console.log(`${this.name} лает.`);
  }
}

let d = new Dog('Митци');
d.speak(); // Митци лает

// Для аналогичных методов дочерний метод имеет приоритет над родительским.
```

Обратите внимание, что классы не могут расширять обычные (non-constructible) объекты. Если вам необходимо создать наследование от обычного объекта, в качестве замены можно использовать Object.setPrototypeOf():

```
var Animal = {
  speak() {
    console.log(`${this.name} издаёт звук.`);
  }
};

class Dog {
  constructor(name) {
    this.name = name;
  }
}

// Если вы этого не сделаете, вы получите ошибку TypeError при вызове speak.
Object.setPrototypeOf(Dog.prototype, Animal);

let d = new Dog('Митци');
d.speak(); // Митци издаёт звук.
```

### Обращение к родительскому классу с помощью `super`
Ключевое слово `super` используется для вызова функций на родителе объекта.

```
class Cat {
  constructor(name) {
    this.name = name;
  }

  speak() {
    console.log(`${this.name} издаёт звук.`);
  }
}

class Lion extends Cat {
  speak() {
    super.speak();
    console.log(`${this.name} рычит.`);
  }
}

let l = new Lion('Фаззи');
l.speak();
// Фаззи издаёт звук.
// Фаззи рычит.
```

## Клиентский веб API
При написании клиентского JavaScript для приложений или веб-сайтов вам не приходится слишком сильно углубляться, пока вы не начнёте использовать API — интерфейсы управления различными аспектами браузера или операционной системы на которой этот сайт работает, или же с данными с других веб-сайтов или сервисов. В этом модуле мы рассмотрим что API из себя представляет и как использовать самые распространённые из них, с которыми вы можете столкнуться в разработке.