#include <iostream>
#include <opencv2/opencv.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <string>
#include <vector>

// Class to interact with Android Debug Bridge (ADB)
class ADB {
private:
	std::string device_id;  // Unique device identifier

public:
	// Constructor that initializes the device id
	ADB(std::string id) : device_id(id) {}

	// Method to capture the screen of the device
	void screen_capture(std::string name) {
		std::string command = "adb -s " + device_id + " exec-out screencap -p > " + name + ".png";
		system(command.c_str());
	}

	// Method to simulate a click on the device at the given coordinates
	void click(int x, int y) {
		std::string command = "adb -s " + device_id + " shell input tap " + std::to_string(x) + " " + std::to_string(y);
		system(command.c_str());
	}

	// Method to find a template image within another image
	std::vector<cv::Point> find(std::string img, std::string template_pic_name = "", double threshold = 0.99) {
		if (template_pic_name.empty()) {
			screen_capture(device_id);
			template_pic_name = device_id + ".png";
		}
		else {
			screen_capture(template_pic_name);
		}

		cv::Mat img_mat = cv::imread(img, cv::IMREAD_COLOR);
		cv::Mat template_mat = cv::imread(template_pic_name, cv::IMREAD_COLOR);

		cv::Mat result;
		cv::matchTemplate(img_mat, template_mat, result, cv::TM_CCOEFF_NORMED);

		std::vector<cv::Point> points;
		for (int i = 0; i < result.rows; i++) {
			for (int j = 0; j < result.cols; j++) {
				if (result.at<float>(i, j) >= threshold) {
					points.push_back(cv::Point(j, i));
				}
			}
		}

		return points;
	}
};

int main() {
	ADB d("emulator-5554");
	std::vector<cv::Point> points = d.find("name.png");
	if (!points.empty()) {
		std::cout << "Point: (" << points[0].x << ", " << points[0].y << ")\n";
		d.click(points[0].x, points[0].y);
	}
	else {
		std::cout << "No match found.\n";
	}

	return 0;
}