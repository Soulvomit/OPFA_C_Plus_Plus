// Copyright Louis Dionne 2013-2017
// Distributed under the Boost Software License, Version 1.0.
// (See accompanying file LICENSE.md or copy at http://boost.org/LICENSE_1_0.txt)

#include "measure.hpp"
#include <cstdlib>
#include <numeric>
#include <vector>


int main () {
    boost::hana::benchmark::measure([] {
        long long result = 0;
        for (int iteration = 0; iteration < 1 << 10; ++iteration) {
            std::vector<int> values = {
                <%= input_size.times.map { 'std::rand()' }.join(', ') %>
            };

            result += std::accumulate(values.begin(), values.end(), 0);
        }
    });
}
