# frozen_string_literal: true

# Copyright 2020, John Gaskin <brotherbain@gmail.com>
#
# This file is part of LionEditor.
#
# LionEditor is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# LionEditor is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with LionEditor.  If not, see <http://www.gnu.org/licenses/>.

module Datatypes
  class Proposition
    attr_accessor :day_increment,
                  :proposition_number,
                  :days_counter,
                  :days_needed,
                  :number_chars,
                  :starting_location,
                  :characters

    def initialize(day_increment: 0, proposition_number: 0, proposition_increment: 0, days_counter: 0,
                   days_needed: 0, number_chars: 0, starting_location: nil, characters: [])
      @day_increment = day_increment
      @proposition_number = proposition_number
      @proposition_increment = proposition_increment
      @days_counter = days_counter
      @days_needed = days_needed
      @number_chars = number_chars
      @starting_location = starting_location
      @characters = characters
    end
  end
end
