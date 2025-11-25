#include "GetCurlCommand.h"
#include <iostream>
#include <curl/curl.h>

using namespace std;

size_t WriteCallback(char* ptr, size_t size, size_t nmemb, std::string* responseData) {
    size_t totalSize = size * nmemb;
    responseData->append(ptr, totalSize);
    return totalSize;
}

void GetCurlCommand::runCommand(string cmd) {
	if (cmd == "get_curl") {
        SetConsoleOutputCP(CP_UTF8); //UTF-8にする
        CURL* hnd; //ハンドル
        CURLcode res; //ステータスコード
        std::string responseData; //保存するデータ

        hnd = curl_easy_init(); //ハンドルを初期化する
        if (hnd) {
            curl_easy_setopt(hnd, CURLOPT_URL, "https://example.com"); //URL
            curl_easy_setopt(hnd, CURLOPT_WRITEFUNCTION, WriteCallback);
            curl_easy_setopt(hnd, CURLOPT_WRITEDATA, &responseData); //データを書き込む

            curl_easy_setopt(hnd, CURLOPT_BUFFERSIZE, 102400L); //バッファサイズ
            curl_easy_setopt(hnd, CURLOPT_MAXREDIRS, 50L);
            curl_easy_setopt(hnd, CURLOPT_HTTP_VERSION, (long)CURL_HTTP_VERSION_2TLS); //HTTPSのバージョン
            curl_easy_setopt(hnd, CURLOPT_TCP_KEEPALIVE, 1L);
            curl_easy_setopt(hnd, CURLOPT_NOPROGRESS, 1L);
            curl_easy_setopt(hnd, CURLOPT_USERAGENT, "curl/7.88.1"); //ユーザーエージェント（識別の名前）

            res = curl_easy_perform(hnd);

            if (res != CURLE_OK) { //OKじゃない
                cout << "失敗" << endl;
            }
            else { //OK
                cout << "成功: " << responseData << std::endl;
            }

            curl_easy_cleanup(hnd); //ハンドルを終了する
        }
	}
	return;
}
