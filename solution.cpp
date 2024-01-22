```cpp
#include <iostream>
#include <unordered_map>
#include <vector>
#include <sstream>

using namespace std;

class FileSystem {
public:
    FileSystem() {
        dirs[""] = unordered_map<string, string>();
    }
    
    vector<string> ls(string path) {
        if (dirs.find(path) != dirs.end()) {
            vector<string> res(dirs[path].begin(), dirs[path].end());
            sort(res.begin(), res.end());
            return res;
        }
        int idx = path.find_last_of('/');
        string dir = path.substr(0, idx), file = path.substr(idx + 1);
        return {file};
    }
    
    void mkdir(string path) {
        istringstream is(path);
        string t = "", dir = "";
        while (getline(is, t, '/')) {
            if (t.empty()) continue;
            if (dir.empty()) dir += "/";
            dirs[dir][t] = "";
            if (dir.size() > 1) dir += "/";
            dir += t;
        }
    }
    
    void addContentToFile(string filePath, string content) {
        int idx = filePath.find_last_of('/');
        string dir = filePath.substr(0, idx), file = filePath.substr(idx + 1);
        dirs[dir][file] = content;
    }
    
    string readContentFromFile(string filePath) {
        int idx = filePath.find_last_of('/');
        string dir = filePath.substr(0, idx), file = filePath.substr(idx + 1);
        return dirs[dir][file];
    }
    
private:
    unordered_map<string, unordered_map<string, string>> dirs;
};

int main() {
    FileSystem fs;
    fs.mkdir("/a/b/c");
    fs.addContentToFile("/a/b/c/d", "hello");
    cout << fs.readContentFromFile("/a/b/c/d") << endl;
    return 0;
}
```