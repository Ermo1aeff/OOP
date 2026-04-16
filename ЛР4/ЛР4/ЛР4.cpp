#include <iostream>
#include <vector>
#include <string>
#include <cmath>
#include <algorithm>
#include <random>
#include <windows.h>

using namespace std;

struct MathOp {
    char type;
    double value;
};

int ArrayLength;
vector<double> RealsArray;
vector<MathOp> OperationsList;

void ArrayFilling() {
    string Operation;
    while (true) {
        cout << "Операция: ";
        cin >> Operation;

        if (toupper(Operation[0]) == 'Q') return;

        try {
            MathOp op;
            op.type = Operation[0];
            op.value = stod(Operation.substr(1));

            OperationsList.push_back(op);
        }
        catch (...) {
            cout << "Ошибка парсинга. Проверьте формат ввода." << endl;
        }
    }
}

void ArrayProcessing() {
    for (const auto& item : OperationsList) {
        for_each(RealsArray.begin(), RealsArray.end(), [&item](double& x) 
        { 
            switch (item.type) {
                case '-':  x -= item.value; break;
                case '+': x += item.value; break;
                case '*': x *= item.value; break;
                case '/': x /= item.value; break;
                case '^': x = pow(x, item.value); break;
                case '%': x = x * 0.01 * item.value; break;
                }
        }); 

        //switch (item.type) {
        //    case '-': for_each(RealsArray.begin(), RealsArray.end(), [&item](double& x) { x -= item.value; }); break;
        //    case '+': for_each(RealsArray.begin(), RealsArray.end(), [&item](double& x) { x += item.value; }); break;
        //    case '*': for_each(RealsArray.begin(), RealsArray.end(), [&item](double& x) { x *= item.value; }); break;
        //    case '/': for_each(RealsArray.begin(), RealsArray.end(), [&item](double& x) { x /= item.value; }); break;
        //    case '^': for_each(RealsArray.begin(), RealsArray.end(), [&item](double& x) { x = pow(x, item.value); }); break;
        //    case '%': for_each(RealsArray.begin(), RealsArray.end(), [&item](double& x) { x = (x / 100.0) * item.value; }); break;
        //}
    }
}

void PrintArray(const vector<double>& arr) {
    cout << "[";
    for (size_t i = 0; i < arr.size(); ++i) {
        cout << arr[i] << (i == arr.size() - 1 ? "" : ", ");
    }
    cout << "]" << endl;
}

int main() {
    setlocale(LC_ALL, "Russian");
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    do {
        cout << "Укажите размер массива от 1 до 10: ";
        if (!(cin >> ArrayLength)) {
            cin.clear();
            cin.ignore(1000, '\n');
            ArrayLength = 0;
        }

        if (ArrayLength < 1 || ArrayLength > 10)
            cout << "Указан не верный размер массива!" << endl;

    } while (ArrayLength < 1 || ArrayLength > 10);

    RealsArray.resize(ArrayLength);

    cout << "Выберите вариант заполнения массива (0-ручной/остальное - случайные числа): ";
    int r;
    if (!(cin >> r)) r = -1; // Защита от ввода символов

    if (r == 0) {
        cout << "Режим ручного заполнения массива:" << endl;
        int i = 0;
        do {
            cout << i << ": ";
            try {
                string input;
                cin >> input;
                RealsArray[i] = stod(input);
                i++;
            }
            catch (...) {
                cout << "Ошибка ввода" << endl;
            }
        } while (i <= ArrayLength - 1);
    }
    else {
        random_device rd;
        mt19937 gen(rd());
        uniform_real_distribution<> dis(0.0, 10.999);

        for (int i = 0; i < ArrayLength; ++i) {
            RealsArray[i] = dis(gen);
        }
    }

    PrintArray(RealsArray);
    ArrayFilling();
    ArrayProcessing();

    cout << "Список операций: [";
    for (size_t i = 0; i < OperationsList.size(); ++i) {
        cout << OperationsList[i].type << OperationsList[i].value;

        if (i < OperationsList.size() - 1) cout << ", ";
    }
    cout << "]" << endl;

    PrintArray(RealsArray);

    return 0;
}